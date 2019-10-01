using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Item pickup;
    private Sprite icon;
    private SpriteRenderer sr;
    private GameObject pc;
    private Inventory inv;

    private void Start()
    {
        #region Refs.
        inv = FindObjectOfType<Inventory>();
        pc = FindObjectOfType<CharacterMovement>().gameObject;
        #endregion
        #region Make the pickup better looking.
        RefreshPickup();
        #endregion
    }

    public void RefreshPickup()
    {
        if (pickup != null)
        {
            if (pickup.sprite != null)
            {
                sr.sprite = pickup.sprite;
            }
            if (pickup.name != null)
            {
                gameObject.name = pickup.name + "Pickup";
            }
            else
            {
                gameObject.name = "UnnamedPickup";
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        GetPickedUp(collision);
    }

    private void GetPickedUp(Collider2D collision)
    {
        if (collision.gameObject == pc)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inv.PickUpItem(pickup);
                Destroy(this.gameObject);
            }
        }
    }
}
