using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public void restartgame(){
        SceneManager.LoadScene("GamePlay");
    }

    public void Homebutton(){
        SceneManager.LoadScene("MainMenu");
    }
}
