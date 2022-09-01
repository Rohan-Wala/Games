using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField]
    private float speed, MaxVelocity;
    private Rigidbody2D mybody;
    private Animator anim;
    
    private float jumpForce = 500f;
    private bool isGrounded = false;

    void Awake()
    {
        mybody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        PlayerWalkKeyboard();   
        PlayerJump();
    }

    private void PlayerWalkKeyboard () {
        float forceX = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);
        Vector3 temp = transform.localScale;

        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0){
            if(vel < MaxVelocity){ 
                forceX = speed;
            }
            //animation
            anim.SetBool("Walk", true);

            //roation
            temp.x = 1;
            transform.localScale = temp;
        }else if(h < 0 ){
            if(vel < MaxVelocity)
                forceX = -speed;
             //animation
            anim.SetBool("Walk", true);

            //roation
            temp.x = -1;
            transform.localScale = temp;

        }else {
            anim.SetBool("Walk",false);
        }

        mybody.AddForce(new Vector2(forceX , 0));
    }

    private void PlayerJump () {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)){
            if(isGrounded){
                mybody.AddForce(new Vector2(0,jumpForce));
                isGrounded = false;
            }
                
        }

    }
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Ground"){
            isGrounded = true;
        }
    }
    
}
