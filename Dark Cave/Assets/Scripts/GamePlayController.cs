using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    private Text scoreText, lifeText;
    private int Score,life;

    void Awake()
    {
        makeInstace();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
         SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene,LoadSceneMode mode){
        if(scene.name == "GamePlay"){
            if(!GameManager.instance.playerDiedGameRestarted){
                Score = 0;
                life = 2;
            }else{
                Score = GameManager.instance.Score;
                life = GameManager.instance.lifeScore;
            }
            scoreText.text = "x" + Score;
            lifeText.text = "x" + life;
        }
    }
    void makeInstace(){
        if(instance == null)
            instance = this;
    }

    public void incrementScore(){
        Score++;
        scoreText.text = "x" + Score;
    }

    public void decrementLife () {
        life--;
        if(life >= 0){
            lifeText.text = "x" + life;
        }
        StartCoroutine(PlayerDied());
    }

    IEnumerator PlayerDied(){
        yield return new WaitForSeconds(2f);
        if(life < 0 )
            SceneManager.LoadScene("MainMenu");
        else{
            GameManager.instance.playerDiedGameRestarted = true;
            GameManager.instance.Score = Score;
            GameManager.instance.lifeScore = life;
            SceneManager.LoadScene("GamePlay");
        }
    }

}
