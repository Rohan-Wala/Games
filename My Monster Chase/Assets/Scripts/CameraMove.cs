using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float min = -76;
    private float max = 76;
    

    private Transform player;

    private Vector3 temppos;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void LateUpdate()
    {
        if(!player)
            return;
            
        temppos = transform.position;
        temppos.x = player.position.x;

        if(player.position.x > max)
            temppos.x = max;
        if(player.position.x < min)
            temppos.x = min;


        transform.position = temppos;

    }
}
