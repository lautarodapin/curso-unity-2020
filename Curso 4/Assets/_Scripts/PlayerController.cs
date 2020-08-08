using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] float force = 1.5f;
    [SerializeField] float powerUpForce = 3f;
    [SerializeField] private GameObject focalPoint;
    float verticalInput;
    private Rigidbody _rigidbody;

    public bool hasPowerUp;
    public float powerUpTime = 10f;

    public GameObject[] powerUpRings;
    void Start()
    {
        focalPoint = GameObject.Find("Focal point");
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.transform.position.y < -10f) this.transform.position = Vector3.zero;
        verticalInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * force * verticalInput);


        foreach (GameObject rings in powerUpRings)
        {
            rings.gameObject.transform.position = this.transform.position + Vector3.up;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy") && hasPowerUp)
        {
            Vector3 direction_push = -(transform.position - other.gameObject.transform.position).normalized;
            Rigidbody enemy_rigidbody = other.gameObject.GetComponent<Rigidbody>();
            enemy_rigidbody.AddForce(direction_push * powerUpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("power up"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine("PowerUpCountdown");
        }
    }


    IEnumerator PowerUpCountdown()
    {   
        foreach (GameObject ring in powerUpRings)
        {
            ring.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime/powerUpRings.Length);
            ring.gameObject.SetActive(false);
            
        }
        hasPowerUp = false;
    }
}
