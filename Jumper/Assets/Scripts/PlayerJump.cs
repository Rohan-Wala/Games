using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D mybody;
    
    private GameObject parent;
    private Button jumpBut;
    //score
    private Text scoreText;
    private Text highScoreText;

    private bool hasJump,platfromBound;
    private int score,maxscore;

    public delegate void MoveCamera(); 
    public static event MoveCamera move;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        jumpBut = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpBut.onClick.AddListener(() => playerJump());
        //score
        scoreText = GameObject.Find("score").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();


        scoreText.text = score.ToString();

        if(PlayerPrefs.HasKey("maxscore")){
            maxscore = PlayerPrefs.GetInt("maxscore");
            highScoreText.text = "High Score: " + maxscore.ToString();
        }
    }
    void Start()
    {
        if(maxscore < score)
            maxscore = score;
        maxscore = PlayerPrefs.GetInt("maxscore",0);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasJump  && mybody.velocity.y == 0){
            if(!platfromBound){
                hasJump = false;
                
                score++;
                scoreText.text = score.ToString();
                updateHighSCore();
                
                transform.SetParent(parent.transform);
                GamePlayController.intance.makePlatfrom();

                if(move != null){
                    move();
                }
            } else if(parent != null){
                transform.SetParent(parent.transform);
            }
        }
    }

    public void playerJump(){
        if(mybody.velocity.y == 0){
            mybody.velocity = new Vector2(0,10);
            hasJump = true;
            transform.SetParent(null);
            }
    }

    public void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Platfrom"){
            parent = target.gameObject;
        }
    }
    public void OnCollisionExit2D(Collision2D target) {
        if(target.gameObject.tag == "Platfrom")
            parent = null;
    }   

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "MainCamera"){
            platfromBound = true;
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if(target.tag == "MainCamera"){
            platfromBound = false;
        }
    }

    void updateHighSCore(){
        if(score > maxscore){
            maxscore = score;
            highScoreText.text = "High Score: " + maxscore.ToString();
            PlayerPrefs.SetInt("maxscore",maxscore); 
        }
    }
}
