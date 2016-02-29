using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;
using System.Collections;
using System.Collections.Generic;

public class PlotManager : MonoBehaviour {

    private List<PlotItem> plots;
    private PlotItem activePlot;
    private Button[] optionButtons;
    private Text[] lines;

    // Use this for initialization
    void Start () {
        /* TODO: Many NPCs */
        plots = FindObjectOfType<NPC>().plots;
        FindObjectOfType<NPC>().OnDialogue += setupPlot;
        lines = GetComponentsInChildren<Text>();
        optionButtons = GetComponentsInChildren<Button>();
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
	}

    private PlotItem getPlot(string id)
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

    // Update is called once per frame
    void Update () {
	
	}

    public string updatePlot(PlotItem newPlot) {
        activePlot = newPlot;
        lines[0].text = newPlot.speaker + ": " + newPlot.plot.line;
        for (int i = 1; i < lines.Length; i++)
        {
            if (newPlot.options.Count >= i && newPlot.options[i - 1].line.Length > 0)
            {
                optionButtons[i - 1].gameObject.SetActive(true);
                if (optionButtons[i - 1].onClick.GetPersistentEventCount() == 0)
                    UnityEventTools.AddStringPersistentListener(optionButtons[i - 1].onClick, setupPlot, newPlot.options[i - 1].next);
                else
                    UnityEventTools.RegisterStringPersistentListener(optionButtons[i - 1].onClick, 0, setupPlot, newPlot.options[i - 1].next);
                lines[i].text = newPlot.options[i - 1].line;
            } else
            {
                optionButtons[i - 1].gameObject.SetActive(false);
            }
        }
        return null;
    }

    void setupPlot()
    {
        setupPlot("1");
    }

    void setupPlot(string nextId)
    {
        if (nextId != "end")
        {
            PlotItem nextPlot = getPlot(nextId);
            updatePlot(nextPlot);
        }
    }

    /* TODO: Test*/
    void OnMouseDown()
    {
        if (activePlot.plot.next.Length == 0)
        {
            PlotItem nextPlot = getPlot(activePlot.plot.next);
            updatePlot(nextPlot);
        }
    }
}
