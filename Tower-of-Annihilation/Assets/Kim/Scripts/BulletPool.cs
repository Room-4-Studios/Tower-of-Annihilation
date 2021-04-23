using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Mq2zYk5tW_E
/* Example of an Object Pool pattern.
 * 
 * Avoid expensive acquisition and release of resources by recycling objects that are no longer in use
 * The Object Pool lets others "check out" objects from its pool, when those objects are no longer 
 * needed by their processes, they are returned to the pool in order to be reused.
 * 
 * 
 */

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets; //Create pool.

    private void Awake() //Only one pool instance.
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>(); //Instantiate bullet prefab here.
    }

    public GameObject GetBullet() 
    {
        if (bullets.Count > 0)
        {
            for(int i=0; i<bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBullets)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }


}
