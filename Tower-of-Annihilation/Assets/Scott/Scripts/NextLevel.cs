using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int randLevel;
    private int[] levelArr = {0, 0, 0};
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
            randLevel = Random.Range(2,5); 
            for(int i = 0; i <= 2; i++)
            {
                if(randLevel == levelArr[i])
                {
                    randLevel = Random.Range(2, 5);
                    i = 0;
                }
            }
            for(int i = 0; i <= 2; i++)
            {
                if(levelArr[i] == 0)
                {
                    levelArr[i] = randLevel;
                    SceneManager.LoadScene(randLevel);
                    break;
                }
            }
            if(NLColliderTouches == 4)
            {
                SceneManager.LoadScene("Boss Scene");
            }
            
            //Debug.Log("Arr contents; " + levelArr[0] + ", " + levelArr[1] + ", " + levelArr[2] + "\n");
           
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