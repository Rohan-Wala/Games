using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void exitGame(){
       Application.Quit();
    }

    public void playGame(){
        int selectedChar = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManagers.instance.charIndex = selectedChar;

        SceneManager.LoadScene("GamePlay");

    }
}
