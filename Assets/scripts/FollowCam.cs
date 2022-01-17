using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject player;

    private Vector3 lastplayerposition;
    private float _distancetomove;

    private void Start()
    {
        
        lastplayerposition = player.transform.position;
    }

    void LateUpdate()
    {

        _distancetomove = player.transform.position.y- lastplayerposition.y;
        transform.position = new Vector3(transform.position.x ,  transform.position.y+_distancetomove, transform.position.z );
        lastplayerposition = player.transform.position;
    }

}
