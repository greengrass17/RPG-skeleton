using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlotManager : MonoBehaviour {

    [HideInInspector]
    public string[] plots;

    [HideInInspector]
    public Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        char separator = '\n';
        plots = text.text.Split(separator);
        text.text = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextLine() {

    }
}
