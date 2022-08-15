using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagers : MonoBehaviour
{
    [SerializeField]
    private GameObject[] character;

    public static GameManagers instance;

    private int _charIndex;
    public int charIndex{
        get{ return _charIndex; }
        set{ _charIndex = value; }
    }
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }else{
            Destroy(gameObject);
        }
    }
    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    public void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading( Scene scene , LoadSceneMode mode){
        if(scene.name == "GamePlay"){
            Debug.Log("he;;o");
            Instantiate(character[charIndex]);
        }
    }
    
}
