using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromCollector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Platfrom"){
            Destroy(target.gameObject);
        }
        if(target.tag == "Player"){
            Time.timeScale = 0f;
            GamePlayController.intance.pausegame();
        }
    }
}
