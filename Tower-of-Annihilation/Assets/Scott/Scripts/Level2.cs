using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    /* when player and collider at top of stairs are touching and "Return" key is
     * pressed the next level will be initiated. */
    private void OnCollisionStay2D(Collision2D Collision)
    {
        if (Collision.gameObject.name == "NLCollider")
        {
             SceneManager.LoadScene(2);
        }
    }
}