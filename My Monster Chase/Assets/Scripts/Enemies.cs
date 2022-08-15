using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    private Rigidbody2D mybody;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
       mybody.velocity = new Vector2(speed , mybody.velocity.y);
    }
}
