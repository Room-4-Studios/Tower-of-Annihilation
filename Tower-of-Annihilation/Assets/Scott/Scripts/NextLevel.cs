using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int randLevel;
    private int[] levelArr = {0, 0, 0, 0, 0};
    private int NLColliderTouches = 0;

    /* when player and collider at top of stairs are touching 
     * the next level will be initiated. */
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        /* If the player touches the collider and all enemies are eliminated, if statement is called */
        if (Collision.gameObject.name == "NLCollider")
        {
            SceneManager.LoadScene("Boss Scene");
            // /* Scene changes */
            // NLColliderTouches++;
            // if (NLColliderTouches == 6)
            // {
            //     SceneManager.LoadScene("Boss Scene");
            // }

            // randLevel = Random.Range(2, 7);
            // while (randLevel == levelArr[0] || randLevel == levelArr[1] || randLevel == levelArr[2] || randLevel == levelArr[3] || randLevel == levelArr[4])
            // {
            //     randLevel = Random.Range(2, 7);
            // }
            // for(int i = 0; i <= 4; i++)
            // {
            //     if(levelArr[i] == 0)
            //     {
            //         levelArr[i] = randLevel;
            //         SceneManager.LoadScene(randLevel);
            //         break;
            //     }
            // }
        }

        else if (Collision.gameObject.name == "ShopCollider")
        {
            SceneManager.LoadScene("ShopKeeper Level");
        }
    }
}