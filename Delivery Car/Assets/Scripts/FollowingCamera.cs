using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
   
    void LateUpdate()
    {
       /*Vector3 playerPos = player.transform.position;
       transform.position = new Vector3(playerPos.x, playerPos.y, -0.5f);*/
       transform.position = player.transform.position + new Vector3(0f, 0f, -10); //equate the camera position to player position, but added -10 to the z-axis because camera must be able to see objects
    }
}

