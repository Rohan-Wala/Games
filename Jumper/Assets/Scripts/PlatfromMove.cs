using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromMove : MonoBehaviour
{

    private float Boundleft = -1.3f , Boundright = 1.3f;
    private bool left;
    private float speed;
    // Start is called before the first frame update
    void Awake()
    {
        RandomizedMovement();
        speed = RandomizedSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void RandomizedMovement () {
        if(Random.Range(0,2) == 0)
            left = true;
        else 
            left = false;
    }
    public float RandomizedSpeed () {
        return (Random.Range(1f,6f));
    }

    public void move(){
        if(left){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
            if(transform.position.x < Boundleft)
                left = false;
        }else{
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
            if(transform.position.x > Boundright)
                left = true;
        }
    }
}
