using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private List<GameObject> _leftSide;
    private List<GameObject> _rightSide;

    private GameObject _currentObject;

    public Transform LeftEnd;
    public Transform RightEnd;

    
    public ObjectPool pooler;
    public Ball_movement ball;


    private void Start()
    {
        _leftSide = new List<GameObject>();
        _rightSide = new List<GameObject>();
    }

    private void Update()
    {
       // if (ball.gamestarted)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddtoRight();

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Addtoleft();
            }

            #region Mobile

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.position.x < Screen.width / 2)
                {
                    AddtoRight();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    Addtoleft();
                }
                
            }
            #endregion

        }

    }

    private void AddtoRight()
    {
        _currentObject = pooler.Getpooledobjects();
        
        if (_rightSide.Count <1)
        {

            _currentObject.transform.position = new Vector3(RightEnd.position.x, RightEnd.position.y+ _currentObject.gameObject.transform.localScale.y, RightEnd.position.z);
        }
        else
        {
            GameObject lastobj = _rightSide[_rightSide.Count - 1].gameObject;
            

             _currentObject.transform.position = new Vector3(RightEnd.position.x, lastobj.transform.position.y + _currentObject.gameObject.transform.localScale.y, RightEnd.position.z);

        }
        _currentObject.transform.position = new Vector3(_currentObject.transform.position.x, _currentObject.transform.position.y + 10f, _currentObject.transform.position.z);
        _currentObject.GetComponentInChildren<Collider>().gameObject.tag = "right";
        _currentObject.SetActive(true);
        _rightSide.Add(_currentObject);
         
    }

    private void Addtoleft()
    {
        _currentObject = pooler.Getpooledobjects();

        if (_leftSide.Count < 1)
        {

            _currentObject.transform.position = new Vector3(LeftEnd.position.x, LeftEnd.position.y + _currentObject.gameObject.transform.localScale.y, LeftEnd.position.z);
        }
        else
        {
            GameObject lastobj = _leftSide[_leftSide.Count - 1].gameObject;


            _currentObject.transform.position = new Vector3(LeftEnd.position.x, lastobj.transform.position.y + _currentObject.gameObject.transform.localScale.y, LeftEnd.position.z);

        }
        _currentObject.transform.position = new Vector3(_currentObject.transform.position.x, _currentObject.transform.position.y + 10f, _currentObject.transform.position.z);

        _currentObject.GetComponentInChildren<Collider>().gameObject.tag = "left";
        _currentObject.SetActive(true);
        _leftSide.Add(_currentObject);

    }



}
