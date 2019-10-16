﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField]
    private LightSystem ls;

    private bool playerNear = false;
    private bool switchOn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterMovement>())
        {
            playerNear = true;
        }

        if (collision.gameObject.GetComponent<EnemyAI>())
        {
            print("in");
            if(collision.gameObject.GetComponent<EnemyAI>().WantToSwitchLight)
            {
                print("stc");
                switchLight();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CharacterMovement>())
        {
            playerNear = false;
        }
    }

    private void Update()
    {
        if(playerNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                switchLight();
            }
        }
    }

    private void switchLight()
    {
        if(switchOn)
        {
            switchOn = false;
        }
        else
        {
            switchOn = true;
        }

        if(switchOn)
        {
            ls.TurnOnLight();
        }
        else
        {
            ls.TurnOffLight();
        }
    }
}