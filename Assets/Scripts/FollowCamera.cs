using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
        //camera will lag in the air on death
        if (thingToFollow.transform.position.y < -10){
            transform.position = new Vector3(thingToFollow.transform.position.x, -10, -10);
        }
        //otherwise it follows the player
        else{
            transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);   
        }     
    }


}
