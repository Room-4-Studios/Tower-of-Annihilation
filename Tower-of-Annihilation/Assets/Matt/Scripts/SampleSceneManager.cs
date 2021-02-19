using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSceneManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Slime;

    void Start()
    {
        float x = Random.Range(-6, 6);
        float y = Random.Range(-6, 6);

        Instantiate(Slime, new Vector2(3,1), Quaternion.identity);
        Instantiate(Player, new Vector2(3,1), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
