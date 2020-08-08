using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody _rigidbody;
    GameObject target;
    public float force = 5f; 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }
    private void Update()
    {
        Vector3 targetDirection = (target.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(targetDirection * force, ForceMode.Force); 
    }
}
