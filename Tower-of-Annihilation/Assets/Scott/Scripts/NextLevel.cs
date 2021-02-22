using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    /* when player and collider at top of stairs are touching 
     * the next level will be initiated. */
    private void OnCollisionStay2D(Collision2D Collision)
    {
        if (Collision.gameObject.name == "NLCollider")
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}