using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* when player and collider at top of stairs are touching and "Return" key is
     * pressed the next level will be initiated. */
    private void OnCollisionStay2D(Collision2D Collision)
    {
        if (Collision.gameObject.name == "Collider3" && Input.GetKey(KeyCode.Return))
        {
             SceneManager.LoadScene(1);
        }
    }
}