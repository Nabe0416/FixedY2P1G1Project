using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ThrowableGameObj : MonoBehaviour
{
    private GameObject tilemap;
    private bool madeSound = false;
    private int targetTime = 480;
    private bool effectDown = false;
    public static bool thrown = false;
    private int targetTime = 960;
    private bool effectDown = false;
    public static bool thrown = false;

    private Item item;

    [SerializeField]
    private GameObject soundsrc;

    private List<GameObject> hearingList = new List<GameObject>();

    private void Start()
    {
        #region Refs.
        tilemap = FindObjectOfType<Tilemap>().gameObject;
        item = this.GetComponent<PickUp>().pickup;
        #endregion
    }

    private void Update()
    {
        MakeStoppedObj();
        if(item.GetType() == typeof(PotionItem))
        {
            effectTimer();
        }
    }

    //Temp method for testing object.
    private void MakeStoppedObj()
    {
        if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude < 0.2f)
        {
            if(GetComponent<CircleCollider2D>().isTrigger == false)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<CircleCollider2D>().isTrigger = true;
                MakeSound();
                if(item.GetType() == typeof(PotionItem) && thrown == true)
                {
                    effectDown = true;
                } 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == tilemap)
        {
            if (GetComponent<CircleCollider2D>().isTrigger == false)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<CircleCollider2D>().isTrigger = true;
                MakeSound();
                if(item.GetType() == typeof(PotionItem) && thrown == true)
                {
                    effectDown = true;
                } 
            }
        }
        if(collision.gameObject.GetComponent<EnemyAI>())
        {
            if(item.GetType() == typeof(ThrowableItem))
            {
                ThrowableItem tItem = (ThrowableItem)item;
                Hurt(collision.gameObject.GetComponent<EnemyAI>(), (int)tItem.damage);
                print(collision.gameObject + " is hurt by " + tItem.name + ", the dmg is " + tItem.damage);
            }
            if(item.GetType() == typeof(PotionItem) && thrown == true)
            {
                effectDown = true;
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hearingList.Contains(collision.gameObject) && collision.gameObject.GetComponent<HearRange>())
        {
            hearingList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(hearingList.Contains(collision.gameObject) && collision.gameObject.GetComponent<HearRange>())
        {
            hearingList.Remove(collision.gameObject);
        }
    }

    private void MakeSound()
    {
        if(!madeSound)
        {
            foreach (GameObject go in hearingList)
            {
                var sSrc = Instantiate(soundsrc, this.transform.position, Quaternion.identity);

                print(go.transform.parent.transform.parent + " is attracted by " + item.name);
                //go.GetComponent<HearRange>
            }
        }
        madeSound = true;
    }

    private void Hurt(EnemyAI ai, int damage)
    {
        ai.DamageHP(damage);
        Destroy(this.gameObject);//Temp method.
    }
    
    private void effectTimer()
    {
        if(effectDown)
        {
            if(thrown)
            {
                effectCollider(this.gameObject);
            }
            thrown = false;
            targetTime -= 1;
            if (targetTime <= 0) 
            {
                destroyEffect();
            }
        }
    }

    private void effectCollider(GameObject gameObject)
    {
        gameObject.AddComponent<AreaEffect>();
        gameObject.GetComponent<CircleCollider2D>().radius = 2.0f;
        gameObject.AddComponent<ParticleSystem>();
    }

    private void destroyEffect()
    {
        Destroy(gameObject);
        effectDown = false;
        targetTime  = 960;
        thrown = false;
    }
}
