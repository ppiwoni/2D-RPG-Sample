using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TreasureChest : Interactable {

    public Item[] items;
    public Animator anim;
    public AudioClip audioClip;


    public override void Interact()
    {
        base.Interact();
        CollectTreasure();
    }

    void CollectTreasure()
    {
        foreach (Item i in items)
        {
            Inventory.instance.Add(i);
            
        }

        anim.GetComponent<Animator>().SetTrigger("Play");

        AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);

        Destroy(gameObject);
       

    }
}
