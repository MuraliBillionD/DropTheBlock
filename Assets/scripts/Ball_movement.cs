using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float Speed;
    public float Direction;
    private bool _moveRight;
    private float _currentdirection;
    public bool gamestarted;



    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        _moveRight = true;
        gamestarted = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gamestarted = true;

        }

        if (gamestarted)
        {
            _rigidbody.isKinematic = false;

            if (_moveRight == true)
            {
                _currentdirection = Direction;

            }
            else
            {
                _currentdirection = -Direction;
            }
        }
        else
        {
            _rigidbody.isKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        float randomX = Random.Range(-1, 2);
        float randomY = Random.Range(-1, 3);
        _rigidbody.velocity = new Vector3(_currentdirection+randomX, Speed+randomY, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="left")
        {
            _moveRight = true;
        }

        if (collision.gameObject.tag == "right")
        {
            _moveRight = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="dead")
        {
            SceneManager.LoadScene(0);
        }
    }
}
