using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementx;

    private Rigidbody2D mybody;
    private Animator anim;
    private SpriteRenderer sprit;

    private string walkstring = "Walk";

    private string enemieTag = "Enemie";

    private bool isGrounded = false;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprit = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        animatePLayer();
        playerJump();
    }

    void playerMove(){
        movementx = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementx , 0f, 0f ) * Time.deltaTime* moveForce;
    }

    void animatePLayer(){

        if(movementx == 0)
            anim.SetBool(walkstring , false);
        else if(movementx > 0){
            anim.SetBool(walkstring, true);
            sprit.flipX = false;
        }else if(movementx < 0){
            anim.SetBool(walkstring, true);
            sprit.flipX = true;
        }
    }

    void playerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded == false){
            mybody.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
            isGrounded = true;
        }
    }

    //for any collicion 
    private void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }

        if(target.gameObject.CompareTag(enemieTag)){
            Destroy(gameObject);
        }
    }

    //for game object with triger
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.CompareTag(enemieTag))
            Destroy(gameObject);
    }
    
}
