using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public bool moveLeft = true;
    private int _direction;
    private float speed;
    [SerializeField]private float minSpeed = 10f;
    [SerializeField]private float maxSpeed = 20f;

    private PlayerController _playerController;

    public float yRangeBound = 10f;

    void Start()
    {
        if (moveLeft) _direction = -1;
        else _direction = 1;
        speed = Random.Range(minSpeed, maxSpeed);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!_playerController.GameOver) transform.Translate(Vector3.right * speed * Time.deltaTime * _direction, Space.World);
        if (Mathf.Abs(this.transform.position.y) > this.yRangeBound) Destroy(this.gameObject);
    }
}
