using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class NPC : ItemGeneral {

    bool dialogueOn;

    CursorLockMode wantedMode;

    void Update ()
    {

    }

    public override void UseItem () {
        Debug.Log("Talk, NPC");
        dialogueOn = true;
        PlotManager dialogue = GameObject.FindObjectOfType<PlotManager>();
        dialogue.text.text = dialogue.plots[0];
        GameObject textBox = GameObject.Find("Dialogue");
        
    }

}
