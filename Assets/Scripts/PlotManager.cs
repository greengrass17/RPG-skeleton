using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;
using System.Collections;
using System.Collections.Generic;

public class PlotManager : MonoBehaviour {

    private List<PlotItem> plots;
    private List<Situation> situations;
    private PlotItem activePlot;
    private Button[] optionButtons;
    private Text[] dialogueTexts;

    // Use this for initialization
    void Start () {
        NPC[] npcs = FindObjectsOfType<NPC>();
        foreach (NPC npc in npcs)
        {
            npc.OnDialogue += setupPlot;
        }
        dialogueTexts = GetComponentsInChildren<Text>();
        optionButtons = GetComponentsInChildren<Button>();
        resetPlot();
	}

    void resetPlot()
    {
        foreach (Text dialogue in dialogueTexts)
        {
            dialogue.text = null;
        }
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    void setupPlot(NPC npc, string initPlot)
    {
        plots = npc.plots;
        situations = npc.situations;
        setupPlot(initPlot);
    }

    void setupPlot(string nextId)
    {
        /* TODO: dynamic ending */
        string[] next = nextId.Split(':');
        if (next[0] != "end")
        {
            PlotItem nextPlot = getNewPlot(nextId);
            updatePlot(nextPlot);
        } else
        {
            if (next.Length > 1)
            {
                int i = 0;
                while (next[1] != situations[i].plotId)
                {
                    i++;
                }
                Inventory inventory = FindObjectOfType<Inventory>();
                inventory.HandleOnItemPickUp(situations[1].matchItem);
                Debug.Log(situations[i].matchItem.displayName);
            }
            resetPlot();
        }
    }

    private PlotItem getNewPlot(string id)
    {
        int i = 0;
        while (id != plots[i].id)
        {
            i++;
        }
        if (i >= plots.Count)
            return null;
        else return plots[i];
    }

    public string updatePlot(PlotItem newPlot) {
        activePlot = newPlot;
        dialogueTexts[0].text = newPlot.speaker + ": " + newPlot.plot.line;
        for (int i = 1; i < dialogueTexts.Length; i++)
        {
            if (newPlot.options.Count >= i && newPlot.options[i - 1].line.Length > 0)
            {
                optionButtons[i - 1].gameObject.SetActive(true);
                if (optionButtons[i - 1].onClick.GetPersistentEventCount() == 0)
                    UnityEventTools.AddStringPersistentListener(optionButtons[i - 1].onClick, setupPlot, newPlot.options[i - 1].next);
                else
                    UnityEventTools.RegisterStringPersistentListener(optionButtons[i - 1].onClick, 0, setupPlot, newPlot.options[i - 1].next);
                dialogueTexts[i].text = newPlot.options[i - 1].line;
            } else
            {
                optionButtons[i - 1].gameObject.SetActive(false);
            }
        }
        return null;
    }

    public void OnMouseDown()
    {
        if (activePlot != null && activePlot.plot.next.Length > 0)
        {
            setupPlot(activePlot.plot.next);
        }
    }
}
