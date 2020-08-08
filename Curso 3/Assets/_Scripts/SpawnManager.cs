using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public float minTimer = 4f;
    public float maxTimer = 10f;

    public float reduceTimer = 0.01f;



    // Start is called before the first frame update1
    void Start()
    {
        Invoke("SpawnEnemy", minTimer);
    }


    void SpawnEnemy(){
        int index = Random.Range(0, enemies.Length);
        Instantiate(enemies[index], this.transform.position, enemies[index].transform.rotation);
        Invoke("SpawnEnemy", Random.Range(minTimer, maxTimer));
        maxTimer -= reduceTimer;
    }
}
