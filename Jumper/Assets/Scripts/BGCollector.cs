using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    private float height = 0f;
   void Awake()
   {
        height = GameObject.Find("BG").GetComponent<BoxCollider2D>().size.y;
   }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Background"){
            Vector3 temp = target.transform.position;
            temp.y += 4 * height;
            target.transform.position = temp;
        }
    }
}
