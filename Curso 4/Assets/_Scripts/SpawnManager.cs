using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    Collider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        CreateEnemy();
        
    }
    
    void CreateEnemy(){        
        Vector3 radius =  _collider.bounds.max;
        Vector3 position = new Vector3(Random.Range(0, radius.x), 0f, Random.Range(0, radius.z));
        Instantiate(enemy, position, enemy.transform.rotation);
    }
}
