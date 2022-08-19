using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private bool canMove;
    private float distance = 4.1f;
    private float newDestination;


    void OnEnable() {
        PlayerJump.move += Move;
    }

    void OnDisable() {
        PlayerJump.move -= Move;    
    }
    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
    
    private void  MoveCamera () {
        if(canMove){
            Vector3 temp = transform.position;
            temp.y += 3f * Time.deltaTime;
            transform.position = temp;
            if(transform.position.y >= newDestination)
                canMove = false;
        }

    }
    void Move(){
        newDestination = transform.position.y + distance;
        canMove = true;
    }
}
