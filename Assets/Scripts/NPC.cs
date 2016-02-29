using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public delegate void OnDialogueEvent();

public class NPC : ItemGeneral {

    public event OnDialogueEvent OnDialogue;

    public List<PlotItem> plots;

    public override void UseItem () {
        if (OnDialogue != null)
        {
            OnDialogue();
        }        
    }

}
