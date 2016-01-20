using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private InventorySlot[] inventorySlots;

    public static ItemPickable activeItem;

	// Use this for initialization
	void Start () {
        inventorySlots = GetComponentsInChildren<InventorySlot>();
        ItemPickable[] itemPickables = FindObjectsOfType<ItemPickable>();
        foreach (ItemPickable item in itemPickables)
        {
            item.OnItemPickUp += HandleOnItemPickUp;
        }
        ItemNotPickable.OnItemUse += HandleOnItemUse;
    }

    private void HandleOnItemPickUp (ItemPickable itemPicked) {
        InventorySlot emptySlot;
        int i = 0;
        do {
            emptySlot = inventorySlots[i];
            i++;
        } while (emptySlot.itemInfo);
        emptySlot.itemInfo = itemPicked;
        Image icon = emptySlot.GetComponent<Image>();
        icon.sprite = emptySlot.itemInfo.inUseIcon;
    }

    private void HandleOnItemUse () {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (activeItem == slot.itemInfo) {
                slot.itemInfo = null;
                slot.GetComponent<Image>().sprite = null;
            }
        }
        activeItem = null;
    }
}
