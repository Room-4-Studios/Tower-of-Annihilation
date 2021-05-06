using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    void FixedUpdate()
    {
        // This function is placed on the main camera, so it finds and follows the player.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
