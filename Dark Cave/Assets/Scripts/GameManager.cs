using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score;
    public int lifeScore;
    public bool playerDiedGameRestarted;


    void Awake()
    {
        makeSingleton();
    }
    public void makeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
