using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private float width = 0f;

    void Awake()
    {
        width = GameObject.Find("BG").GetComponent<BoxCollider2D>().size.x;
        
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "BG" || target.tag == "ground"){
            Vector3 temp = target.transform.position;
            temp.x += width * 3; //move target by width*3 distance
            target.transform.position = temp;
        }
        if(target.tag == "rocket" || target.tag == "coin" || target.tag == "coin2")
            // target.gameObject.SetActive(false);
            Destroy(target.gameObject);
    }

    
}
