using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
        
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 8, -18);

       // Update is called once per frame
    void LateUpdate()
    {
        //To give a camera an position and to follow the player
        transform.position = player.transform.position + offset;
    }
}
