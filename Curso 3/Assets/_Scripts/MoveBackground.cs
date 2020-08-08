using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MoveBackground : MonoBehaviour
{
    public bool moveLeft = true;
    private int _direction;
    [SerializeField]private float speed = 10f;

    public float restartPoint = 10f;
    private Vector3 _start;
    private PlayerController _playerController;

    void Start()
    {
        _start = this.transform.position;
        if (moveLeft) _direction = -1;
        else _direction = 1;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        restartPoint = GetComponent<Collider>().bounds.size.x / 2f;
    }

    void Update()
    {
        if (!_playerController.GameOver) transform.Translate(Vector3.right * speed * Time.deltaTime * _direction, Space.World);
        if (Mathf.Abs(this.transform.position.x) > restartPoint) this.transform.position = _start;
    }
}
