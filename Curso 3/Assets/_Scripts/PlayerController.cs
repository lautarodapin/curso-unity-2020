using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    [SerializeField] float _force = 10f;
    private bool isGround = true;
    private Animator _animator;

    private bool _gameOver;

    public bool GameOver { get => _gameOver; }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();     
        _animator = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver) _animator.SetFloat("Speed_f", 1f);
        if (Input.GetKeyDown(KeyCode.Space) && isGround){
            _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
            isGround = false;
            _animator.SetTrigger("Jump_trig");
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("ground")){
            isGround = true;
        } 
        if (other.collider.CompareTag("obstacle")){
            _gameOver = true;
            _animator.SetBool("Death_b", true);
        }
    }
}
