using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GoldReceive : Interactable {

    public int goldAmount;
    public AudioClip audioClip;

    public override void Interact()
    {
        base.Interact();
        GoldPickUp();
    }

    void GoldPickUp()
    {
        Inventory.instance.ManageGold(goldAmount);

        AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);

        Destroy(gameObject);
    }

}
