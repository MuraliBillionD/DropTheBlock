using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _moveRight;
    private float _currentdirection;
    private bool _start;
    private float _initialPosition;

    public float Speed;
    public float Direction;
 
    public bool gamestarted;


    #region MonoCallBacks
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
       
    }
    private void Start()
    {
        _start = false;
        _moveRight = true;
        gamestarted = false;
        _initialPosition = this.transform.position.y;
        UI_manager.instance.UpdateScore(0);
    }

    private void Update()
    {
        if ( gamestarted==false&&_start==false)
        {
            Invoke("_began", 0.3f);

        }

        _gameActivated();
    }

    private void FixedUpdate()
    {
        float randomX = Random.Range(-1, 2);
        float randomY = Random.Range(0, 2);
        if (gamestarted)
        {
            if (_start)
            {
                _rigidbody.velocity = new Vector3(_currentdirection + randomX, Speed * (5+randomY), 0);
                _start = false;
            }
            else
            {
                int score = (int)((transform.position.y - _initialPosition) / 100);
                _rigidbody.velocity = new Vector3(_currentdirection + randomX, Speed *(3f+ randomY+(score*0.1f)), 0);
            }

         
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "left")
        {
            if (this.transform.position.x <= Playercontroller.instance.LeftEnd.transform.position.x || this.transform.position.x >= Playercontroller.instance.RightEnd.transform.position.x)
            {
                ParticlesSystems.instance.OnWallHIt(collision.GetContact(0).point);
                _Gameover();
                this.gameObject.SetActive(false);
            }
            else
            {
                ParticlesSystems.instance.HitBounce(collision.GetContact(0).point);
                _moveRight = true;
            }
        }

        if ( collision.gameObject.tag == "right")
        {
            if (this.transform.position.x <= Playercontroller.instance.LeftEnd.transform.position.x || this.transform.position.x >= Playercontroller.instance.RightEnd.transform.position.x)
            {
                ParticlesSystems.instance.OnWallHIt(collision.GetContact(0).point);
                _Gameover();
            }
            else
            {
                ParticlesSystems.instance.HitBounce(collision.GetContact(0).point);
                _moveRight = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="dead")
        {
            ParticlesSystems.instance.HitBounce(other.ClosestPoint(transform.position));
            ParticlesSystems.instance.HitEnd(other.ClosestPoint(transform.position));

            _Gameover();
            
        }
    }
    #endregion

    private void _gameActivated()
    {
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

            int Score = (int)((transform.position.y - _initialPosition)/3);
            UI_manager.instance.UpdateScore(Score);

        }
        else
        {
            _rigidbody.isKinematic = true;
        }
    }

    private void _Gameover()
    {
        gamestarted = false;
        _start = true;
        _rigidbody.isKinematic = true;
        int score = (int)((transform.position.y - _initialPosition)/3);

        UI_manager.instance.GameOver(true,score);

        this.gameObject.SetActive(false);
    }

    private void _began()
    {
        _start = true;
        gamestarted = true;
    }


}
