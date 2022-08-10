using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScore : MonoBehaviour
{
    private Text scoretext;
    private Text maxScoreText;
    private int score ;
    private int maxscore;

    private static PlayerScore instance;
    // Start is called before the first frame update
    void Start()
    {   
        if(maxscore < score)
                maxscore = score;
        maxscore = PlayerPrefs.GetInt("maxscore", 0);
    }
    void Awake()
    {
        instance = this;

        scoretext = GameObject.Find("ScoreText").GetComponent<Text>();
        maxScoreText = GameObject.Find("MaxScoreText").GetComponent<Text>();

        scoretext.text = score.ToString();
        if(PlayerPrefs.HasKey("maxscore")){
            maxscore = PlayerPrefs.GetInt("maxscore");
            maxScoreText.text = "Max Score : " + maxscore.ToString();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "coin" ){
            score++;

        updateHighSCore();
        scoretext.text = score.ToString();

        // target.gameObject.SetActive(false);
        Destroy(target.gameObject);
        }
        if(target.tag == "coin2" ){
            score += 2;

        updateHighSCore();
        scoretext.text = score.ToString();

        // target.gameObject.SetActive(false);
        Destroy(target.gameObject);
        }
        
        if(target.tag == "rocket"){
            transform.position = new Vector3(0,1000,0);
            target.gameObject.SetActive(false);
            
            StartCoroutine(Restartgame());
            
        }
        IEnumerator Restartgame(){
                yield return new WaitForSecondsRealtime(3f);
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
    }
    void updateHighSCore(){
        if(score > maxscore){
            maxscore = score;
            maxScoreText.text = "Max Score : " + maxscore.ToString();
            PlayerPrefs.SetInt("maxscore", maxscore);
        }
    }
}
