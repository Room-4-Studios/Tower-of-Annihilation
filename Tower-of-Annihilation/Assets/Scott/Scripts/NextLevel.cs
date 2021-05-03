using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int randLevel;
    private int[] levelArr = {0, 0, 0, 0};
    private int NLColliderTouches = 0;

    /* when player and collider at top of stairs are touching 
     * the next level will be initiated. */
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        /* If the player touches the collider and all enemies are eliminated, if statement is called */
        if (Collision.gameObject.name == "NLCollider" && (GameObject.Find("Slime(Clone)") == null))
        {
            //Debug.Log("Henlo");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); We need to look into this, with more random scenes.
            /* Scene changes */
            NLColliderTouches++;
            if (NLColliderTouches == 5)
            {
                SceneManager.LoadScene("Boss Scene");
            }

            randLevel = Random.Range(2, 6);
            while (randLevel == levelArr[0] || randLevel == levelArr[1] || randLevel == levelArr[2] || randLevel == levelArr[3])
            {
                randLevel = Random.Range(2, 6);
            }
            for(int i = 0; i <= 3; i++)
            {
                if(levelArr[i] == 0)
                {
                    levelArr[i] = randLevel;
                    SceneManager.LoadScene(randLevel);
                    break;
                }
            }
        }

        else if (Collision.gameObject.name == "ShopCollider" && (GameObject.Find("Slime(Clone)") == null))
        {
            //Debug.Log("Henlo");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); We need to look into this, with more random scenes.
            /* Scene changes */
            SceneManager.LoadScene("ShopKeeper Level");
        }
    }
}