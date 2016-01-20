using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public delegate void OnItemUseEvent();

public class ItemNotPickable : ItemGeneral {

    public static event OnItemUseEvent OnItemUse;

    public Sprite usedIcon;

    public ItemPickable matchItem;

	public override void UseItem () {
        // If item should be use
        // Change item sprite
        if (Inventory.activeItem == matchItem)
        {
            GetComponent<SpriteRenderer>().sprite = usedIcon;
            OnItemUse();
        }
    }
}
