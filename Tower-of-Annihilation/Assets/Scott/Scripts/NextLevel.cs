using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    /* when player and collider at top of stairs are touching 
     * the next level will be initiated. */
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.name == "NLCollider")
        {
            //Debug.Log("Henlo");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); We need to look into this, with more random scenes.
            SceneManager.LoadScene("Demo Scene");
        }
    }
}