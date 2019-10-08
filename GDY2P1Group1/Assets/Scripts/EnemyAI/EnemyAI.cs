using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private GameObject tilemap;
    private GameObject pc;

    [SerializeField]
    private ViewRange vr;
    [SerializeField]
    private HearRange hr;

    public bool pcIsInView = false;

    private Transform viewPos;
    private Transform hearPos;

    [SerializeField]
    private Transform lastSeenPos;

    [SerializeField]
    private int Hitpoint;
    private int HitpointMax = 10;

    private void Start()
    {
        #region Refs.
        pc = FindObjectOfType<CharacterMovement>().gameObject;
        tilemap = FindObjectOfType<Tilemap>().gameObject;
        #endregion
        Hitpoint = HitpointMax;
    }

    private void Update()
    {
        if(viewPos != null)
        {
            pcIsInView = true;
        }
        else
        {
            pcIsInView = false;
        }

        CheckHP();
    }

    public void SeePlayerAt(Transform pos)
    {
        if(hearPos) Destroy(hearPos.gameObject);
        viewPos = pos;
        if (pcIsInView) ChasePlayerMode();
        GetComponent<AIDestinationSetter>().target = viewPos;

    }

    public void HearSmtAt(Transform pos)
    {
        hearPos = pos;
        SearchMode();
        if (!pcIsInView) GetComponent<AIDestinationSetter>().target = hearPos;
    }

    public void ShootPlayer()
    {

    }

    private void ChasePlayerMode()
    {
        GetComponent<AIPath>().maxSpeed = 3;
    }

    private void SearchMode()
    {
        GetComponent<AIPath>().maxSpeed = 1;
    }

    public void DamageHP(int value)
    {
        Hitpoint -= value;
    }

    private void CheckHP()
    {
        if(Hitpoint <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print(this.gameObject + " is dead.");
        this.gameObject.SetActive(false);
    }

    public ViewRange GetViewRange()
    {
        return vr;
    }

    public HearRange GetHearRange()
    {
        return hr;
    }
}