using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ItemGeneral : MonoBehaviour {

    public string displayName;

    public string description;

    [HideInInspector]
    public Text text;

    void Start () {
        PlayerControl player = FindObjectOfType<PlayerControl>();
        player.CheckTargetItem += HandleCheckTargetItem;
        GameObject textBox = GameObject.Find("Dialogue");
        text = textBox.GetComponentInChildren<Text>();
    }

    public void HandleCheckTargetItem (Vector3 mouseTarget) {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit2D hit = Physics2D.Raycast(mouseTarget, Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider && hit.transform.GetComponent<ItemGeneral>())
        {
            hit.transform.GetComponent<ItemGeneral>().UseItem();
        }
    }

    public virtual void UseItem () {

    }

}
