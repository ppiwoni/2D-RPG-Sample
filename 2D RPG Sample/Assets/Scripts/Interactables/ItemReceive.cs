using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceive : Interactable {


    public override void Interact()
    {
        base.Interact();
        ItemPickUp();
    }

    void ItemPickUp()
    {

    }
}
