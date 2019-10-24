using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    private bool damageTick = false;
    private float damageTime = 120;

    [SerializeField]
    private List<EnemyAI> enemylist = new List<EnemyAI>();

    private void Update() {
        if(damageTick){
            damageTime -= 1;
            if(damageTime <= 0) 
            {
                for(int i = 0; i < enemylist.Count; i++)
                {
                    Debug.Log("Damage");
                    enemylist[i].DamageHP(4);
                }
                damageTime = 120;
            }
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        damageTick = true;
        if(collision.GetComponent<EnemyAI>())
        {
            enemylist.Add(collision.GetComponent<EnemyAI>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        damageTick = false;
    }
}
