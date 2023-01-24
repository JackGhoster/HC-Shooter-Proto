using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float _speed = 30f;
    private Rigidbody rb;
    private Vector3 _direction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _direction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().BulletDirection;
        _direction.z = 1;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = _direction * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {      
        gameObject.GetComponent<Bullet>().enabled = false;       
    }
    private void OnEnable()
    {
        _direction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().BulletDirection;
        Invoke("TooLongInAir",5f);
    }
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }

    private void TooLongInAir()
    {
        gameObject.SetActive(false);
    }

}
