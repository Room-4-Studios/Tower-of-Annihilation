using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Example of Singleton pattern.
 * Ensure a class has only one instance, and provide a global point of access to it.
 * Encapsulated "just-in-time initialization" or "initialization on first use".
 * 
 */

public class Princess : MonoBehaviour
{
    private static Princess _instance;
    public static Princess Instance { get { return _instance; } }
    private GameObject player;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Reached Princess");
            SceneManager.LoadScene("Ending 2");
            Destroy(player);
        }
    }
}