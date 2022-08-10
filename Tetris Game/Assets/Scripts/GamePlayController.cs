using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject GameOverScreen;

    private void Awake() {
        pausePanel.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void PauseGame(){
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void QuitGame(){
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void GameOver(){
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
    }

    public void Restart(){
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }
    
}
