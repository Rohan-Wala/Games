using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public bool isAlive;
    public GameObject finishText;

    void Awake()
    {
        isAlive = true;
        finishText = GameObject.Find("LevelFinished");
        finishText.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Collectable"){
            GamePlayController.instance.incrementScore();
            target.gameObject.SetActive(false);
        }
        if(target.tag == "Enemy"){
            if(isAlive){
                isAlive = false;
                GamePlayController.instance.decrementLife();
                transform.position = new Vector3(0,1000,0);
            }
            
        }

        if(target.tag == "Exit"){
            Time.timeScale = 0f;
            gameObject.SetActive(false);
            finishText.SetActive(true);
        }


            
    }
}
