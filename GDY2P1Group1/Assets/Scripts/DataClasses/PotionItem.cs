using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PotionItem : ThrowableItem
{
    public uint potionSort;
    private int targetTime = 960;
    public static bool effectDown = false;
    public static bool thrown = false;

    public void effectTimer(GameObject gameObject)
    {
        if(effectDown)
        {
            if(thrown)
            {
                effectCollider(gameObject);
            }
            thrown = false;
            targetTime -= 1;
            if (targetTime <= 0) 
            {
                destroyEffect(gameObject);
            }
        }
    }

    public void destroyEffect(GameObject gameObject)
    {
        Destroy(gameObject);
        targetTime  = 960;
    }

    private void effectCollider(GameObject gameObject)
    {
        gameObject.AddComponent<AreaEffect>();
        gameObject.GetComponent<CircleCollider2D>().radius = 2.0f;
        gameObject.AddComponent<ParticleSystem>();
        thrown = false;
        effectDown = false;
    }
}
