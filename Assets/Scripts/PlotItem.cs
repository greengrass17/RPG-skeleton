using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlotItem {

    public string id;

    public string speaker;

    public PlotLine plot;

    public List<PlotLine> options;

}
