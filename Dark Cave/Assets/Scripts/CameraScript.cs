using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    private PlayerScore playerscore;

    private float minx = 0f ,maxx = 90f;
// Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        playerscore = Player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer(){
        if(playerscore.isAlive){
            Vector3 temp = transform.position;
            temp.x = Player.transform.position.x;
            if(temp.x < minx)
                temp.x = minx;
            if(temp.x > maxx)
                temp.x = maxx;


            temp.y = Player.transform.position.y + 2f;
            transform.position = temp;
        }
    }
}
