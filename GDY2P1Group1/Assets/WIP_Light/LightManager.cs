using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private bool LightOn;

    public SpriteRenderer pcSr;
    private TilemapRenderer mpR;

    [SerializeField]
    private Material darkM;
    [SerializeField]
    private Material normM;

    [SerializeField]
    private List<EnemyAI> enemiesList;

    private void Start()
    {
        #region Refs.        
        mpR = FindObjectOfType<Tilemap>().GetComponent<TilemapRenderer>();
        #endregion
    }

    private void Update()
    {
        /*
        if(LightOn)
        {
            TurnOnLight();
        }
        else
        {
            TurnOffLight();
        }*/
    }
    [ContextMenu("Turn off the light")]
    private void TurnOffLight()
    {
        enemiesList = FindObjectOfType<EnemiesManager>().GetList();
        pcSr.material = darkM;
        mpR.material = darkM;
        foreach(EnemyAI e in enemiesList)
        {
            e.transform.GetChild(0).GetComponent<SpriteRenderer>().material = darkM;
            e.GetViewRange().SetToDarkMode();
        }
    }

    [ContextMenu("Turn on the light")]
    private void TurnOnLight()
    {
        enemiesList = FindObjectOfType<EnemiesManager>().GetList();
        pcSr.material = normM;
        mpR.material = normM;
        foreach (EnemyAI e in enemiesList)
        {
            e.transform.GetChild(0).GetComponent<SpriteRenderer>().material = normM;
            e.GetViewRange().SetToLightMode();
        }
    }
}
