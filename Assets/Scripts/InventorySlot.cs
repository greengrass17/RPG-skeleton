using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour {

    [HideInInspector]
    public ItemPickable itemInfo;

    public void SetActiveItem () {
        Inventory.activeItem = itemInfo;
    }
}
