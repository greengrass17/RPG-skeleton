using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public delegate void OnItemPickUpEvent(ItemPickable item);

public class ItemPickable : ItemGeneral {

    public event OnItemPickUpEvent OnItemPickUp;

    public Sprite inUseIcon;

    public override void UseItem()
    {
        // If item should be pick up
        // Disable game object
        if (OnItemPickUp != null)
        {
            OnItemPickUp(this);
        }
        gameObject.SetActive(false);
    }
}
