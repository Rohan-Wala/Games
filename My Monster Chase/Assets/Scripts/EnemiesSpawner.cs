using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private Transform leftPos , rightPos;

    private GameObject spawnedEnemies;

    private int randomSide , randromIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    IEnumerator spawner(){
       while(true){
            yield return new WaitForSeconds(Random.Range(1,5));
            randromIndex = Random.Range(0, enemies.Length);
            randomSide = Random.Range(0,2);

            spawnedEnemies = Instantiate(enemies[randromIndex]);
            if(randomSide == 0){
                spawnedEnemies.transform.position = leftPos.position;
                spawnedEnemies.GetComponent<Enemies>().speed = Random.Range(4,11);
            }else{
                spawnedEnemies.transform.position = rightPos.position;
                spawnedEnemies.GetComponent<Enemies>().speed = -Random.Range(4,11);
                spawnedEnemies.transform.localScale = new Vector3(-1f,1f,1f);
            }
        }
    }
}
