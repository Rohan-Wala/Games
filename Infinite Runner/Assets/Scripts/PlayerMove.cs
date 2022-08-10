using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{   
    private Button jumpbut;
    private Button ExitBut;
    private Button startBut;
    private GameObject spawner;
    private float speed = 3f;
    private Rigidbody2D mybody;
    void Awake()
    {   //jump
        jumpbut = GameObject.Find("Jump").GetComponent<Button>();
        jumpbut.onClick.AddListener( () => jump());

        //exit
        ExitBut = GameObject.Find("Exit").GetComponent<Button>();
        ExitBut.onClick.AddListener( () => exitgame());
        ExitBut.gameObject.SetActive(false);

        //player
        mybody = GetComponent<Rigidbody2D>();

        //start
        startBut = GameObject.Find("Start").GetComponent<Button>();
        startBut.gameObject.SetActive(true);
        startBut.onClick.AddListener(() => startgame());

        //spawner
        spawner = GameObject.Find("Spawner");
        spawner.gameObject.SetActive(false);


    }
    void Start()
    {
        if(startBut.gameObject.activeInHierarchy == true)
            InvokeRepeating("jump" , 2f ,2f);
        

    }

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
        if(startBut.gameObject.activeInHierarchy == false)
            CancelInvoke("jump");
        
    }

    void jump(){
        mybody.gravityScale *= -1;
        Vector3 temp = transform.localScale;
        temp.y *= -1;
        transform.localScale = temp;
         
    }

    void exitgame(){
        Application.Quit();
    }

    void startgame(){
        startBut.gameObject.SetActive(false);
        ExitBut.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
    }
}
