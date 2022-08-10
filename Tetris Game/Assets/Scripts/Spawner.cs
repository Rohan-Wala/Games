using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] TetrisObject;

    
    // Start is called before the first frame update
    void Start()
    {
        spawnRandom();
    }

    public void spawnRandom(){
        
        int index = Random.Range(0,TetrisObject.Length);
        Instantiate(TetrisObject[index] , transform.position ,Quaternion.identity);
    }
}
