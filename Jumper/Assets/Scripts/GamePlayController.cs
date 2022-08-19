using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController intance;

    [SerializeField]
    private GameObject panel;
    
    [SerializeField]
    private GameObject[] platfrom;

    private float DisatnceBetweenPlatform = 4.1f;
    private int platfromCount;
    private float lastPlatfromPositionY;
    // Start is called before the first frame update
    void Awake()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        makeSingleTun();
        makePlatfrom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable() //when object is distroyed
    {
        intance = null;
    }

    void makeSingleTun(){
        if(intance == null)
            intance = this;
    }

    public void makePlatfrom () {
        lastPlatfromPositionY += DisatnceBetweenPlatform;
        GameObject newPlatfrom = Instantiate(platfrom[Random.Range(0,platfrom.Length)]);
        newPlatfrom.transform.position = new Vector3(0, lastPlatfromPositionY, 0);
        newPlatfrom.name = "Platfrom" + platfromCount;
        platfromCount++;
    }

    public void restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void pausegame(){
        if(panel.activeSelf == false){
            Time.timeScale = 0f;
            panel.SetActive(true);
        }else if (panel.activeSelf == true){
            Time.timeScale = 1f;
            panel.SetActive(false);
        }
    }
}
