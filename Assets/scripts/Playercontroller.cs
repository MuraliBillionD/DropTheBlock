using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private List<GameObject> _leftSide;
    private List<GameObject> _rightSide;
    private bool _placeLeft;
    private bool _placeNow;
    private GameObject _currentObject;
    private Material _storePrevious;

    public Transform LeftEnd;
    public Transform RightEnd;
   
    public ObjectPool pooler;
    public Ball_movement ball;
    public static Playercontroller instance;
    public  float Count;
    

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
        _placeNow = true;
    }

    private void Update()
    {
        if (ball.gamestarted)
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_placeNow == true)
                {
                    _placeNow = false;
                    if (_placeLeft == false)
                    {
                        StartCoroutine(AddtoRight());

                    }
                    else
                    {
                        StartCoroutine(Addtoleft());
                    }
                }
            }
#endif

            #region Mobile

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (_placeNow==true)
                    {
                        _placeNow = false;

                        if (_placeLeft == false)
                        {
                           StartCoroutine( AddtoRight());

                        }
                        else
                        {
                            StartCoroutine( Addtoleft());
                        }
                        
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
    private IEnumerator AddtoRight()
    {
        _currentObject = pooler.Getpooledobjects();
        
        if (_rightSide.Count <1)
        {
            _currentObject.transform.position = new Vector3(RightEnd.position.x,0.2f+ RightEnd.position.y+ _currentObject.gameObject.transform.localScale.y, RightEnd.position.z);
        }
        else
        {
            GameObject lastobj = _rightSide[_rightSide.Count - 1].gameObject;
           
             _currentObject.transform.position = new Vector3(RightEnd.position.x, 0.2f+lastobj.transform.position.y + _currentObject.gameObject.transform.localScale.y, RightEnd.position.z);

        }
        _currentObject.transform.position = new Vector3(_currentObject.transform.position.x, _currentObject.transform.position.y + 10f, _currentObject.transform.position.z);
        _currentObject.GetComponentInChildren<Collider>().gameObject.tag = "right";

        Count++;
        if(Count==150)
        {
            Count = 0;
            LevelController.instance.RandomPalete();
        }

        _currentObject.GetComponentInChildren<MeshRenderer>().material=LevelController.instance._material;
        _storePrevious = _currentObject.GetComponentInChildren<MeshRenderer>().material;
        LevelController.instance.ColorMesh(_currentObject.GetComponentInChildren<MeshFilter>().mesh,Count);
        _currentObject.SetActive(true);
        _rightSide.Add(_currentObject);
        _placeLeft = true;

        yield return new WaitForSeconds(0.03f);
        _placeNow = true;
        
         
    }

    /// <summary>
    /// function responsible for adding Wall to the Left
    /// </summary>
    private IEnumerator Addtoleft()
    {
        _currentObject = pooler.Getpooledobjects();

        if (_leftSide.Count < 1)
        {

            _currentObject.transform.position = new Vector3(LeftEnd.position.x, 0.2f+LeftEnd.position.y + _currentObject.gameObject.transform.localScale.y, LeftEnd.position.z);
        }
        else
        {
            GameObject lastobj = _leftSide[_leftSide.Count - 1].gameObject;


            _currentObject.transform.position = new Vector3(LeftEnd.position.x, 0.2f+lastobj.transform.position.y + _currentObject.gameObject.transform.localScale.y, LeftEnd.position.z);

        }
        _currentObject.transform.position = new Vector3(_currentObject.transform.position.x, _currentObject.transform.position.y + 10f, _currentObject.transform.position.z);

        _currentObject.GetComponentInChildren<Collider>().gameObject.tag = "left";

         _currentObject.GetComponentInChildren<MeshRenderer>().material = LevelController.instance._material;
          LevelController.instance.ColorMesh(_currentObject.GetComponentInChildren<MeshFilter>().mesh,Count);

       // _currentObject.GetComponentInChildren<MeshRenderer>().material = _storePrevious;
        _currentObject.SetActive(true);
        _leftSide.Add(_currentObject);
        _placeLeft = false;

        yield return new WaitForSeconds(0.03f);
        _placeNow = true;

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
