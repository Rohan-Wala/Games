using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    // Update is called once per frame

    
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.CompareTag("Enemie") || target.gameObject.CompareTag("Player"))
            Destroy(target.gameObject);

    }
}
