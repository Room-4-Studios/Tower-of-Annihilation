using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Mq2zYk5tW_E

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
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
