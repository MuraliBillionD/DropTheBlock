using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private List<GameObject> _leftSide;
    private List<GameObject> _rightSide;
    private bool _placeLeft;
    private GameObject _currentObject;
    private Material _storePrevious;

    public Transform LeftEnd;
    public Transform RightEnd;
   
    public ObjectPool pooler;
    public Ball_movement ball;
    public static Playercontroller instance;
    

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
            
        }

        else
        {
            Destroy(gameObject);
        }
        #endregion
    }



    private void Start()
    {
        _leftSide = new List<GameObject>();
        _rightSide = new List<GameObject>();
        _placeLeft = false;
    }

    private void Update()
    {
        if (ball.gamestarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_placeLeft == false)
                {
                    AddtoRight();

                }
                else
                {
                    Addtoleft();
                }
            }

            #region Mobile

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (_placeLeft == false)
                    {
                        AddtoRight();

                    }
                    else
                    {
                        Addtoleft();
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                }

            }
            #endregion

        }

    }
    /// <summary>
    /// function responsible for adding Wall to the Right
    /// </summary>
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

        _currentObject.GetComponentInChildren<MeshRenderer>().material=LevelController.instance._material;
        _storePrevious = _currentObject.GetComponentInChildren<MeshRenderer>().material;
        LevelController.instance.ColorMesh(_currentObject.GetComponentInChildren<MeshFilter>().mesh);
        _currentObject.SetActive(true);
        _rightSide.Add(_currentObject);
       
        _placeLeft = true;
         
    }

    /// <summary>
    /// function responsible for adding Wall to the Left
    /// </summary>
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

         //_currentObject.GetComponentInChildren<MeshRenderer>().material = LevelController.instance._material;
          LevelController.instance.ColorMesh(_currentObject.GetComponentInChildren<MeshFilter>().mesh);

        _currentObject.GetComponentInChildren<MeshRenderer>().material = _storePrevious;
        _currentObject.SetActive(true);
        _leftSide.Add(_currentObject);
        _placeLeft = false;

    }

    public void RemoveFromList(GameObject obj)
    {
        if(obj.GetComponentInChildren<Collider>().gameObject.tag == "left")
        {
            obj.SetActive(false);
            _leftSide.Remove(obj);

        }
        else
        {
            obj.SetActive(false);
            _rightSide.Remove(obj);
        }

    }



}
