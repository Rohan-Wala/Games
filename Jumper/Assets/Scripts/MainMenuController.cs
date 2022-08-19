using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private Button start;
    private Button Quit;
    void Awake()
    {
        start = GameObject.Find("Start").GetComponent<Button>();
        start.onClick.AddListener(()=> startGame());
        Quit = GameObject.Find("Quit").GetComponent<Button>();
        Quit.onClick.AddListener(()=> quitGame());
    }
    void startGame(){
        SceneManager.LoadScene("GamePlay");
    }

    void quitGame(){
        Application.Quit();
    }
    
}
