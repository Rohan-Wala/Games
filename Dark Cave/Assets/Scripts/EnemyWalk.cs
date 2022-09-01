using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    private float speed = 3f;
    [SerializeField]
    private bool walkLeft;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    private void walk(){
            Vector3 temp =transform.position;
            Vector3 tempscale = transform.localScale;

            if(walkLeft){
                temp.x -= speed * Time.deltaTime;
                tempscale.x = -Mathf.Abs(tempscale.x); 
            }else{
                temp.x += speed * Time.deltaTime;
                tempscale.x = Mathf.Abs(tempscale.x); 
            }

            transform.position = temp;
            transform.localScale = tempscale;
    }
    IEnumerator changeDirection()
    {
        yield return new WaitForSeconds(3f);
        walkLeft = !walkLeft;
        StartCoroutine(changeDirection());
    }
}
