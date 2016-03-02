using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public delegate void OnDialogueEvent(NPC npc, string initPlot);

public class NPC : ItemGeneral {

    public event OnDialogueEvent OnDialogue;

    public List<PlotItem> plots;

    public List<Situation> situations;

    public override void UseItem () {
        if (OnDialogue != null)
        {
            int i = 0;
            if (Inventory.activeItem)
            {
                while (Inventory.activeItem != situations[i].matchItem)
                {
                    i++;
                }
                OnDialogue(this, situations[i].plotId);
            }
            else
            {
                OnDialogue(this, "1");
            }
        }        
    }

}
