using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject[] pooledobject;

    private List<GameObject> _Objectspooled;
 

    void Start()
    {
        _Objectspooled = new List<GameObject>();

    }
/// <summary>
/// function responosible for Pooling the Objects
/// </summary>
/// <returns></returns>
    public GameObject Getpooledobjects()
    {
        //checking the availibility of objects that are not active
        for (int i = 0; i < _Objectspooled.Count; i++)
        {
            if (!_Objectspooled[i].activeInHierarchy)
            {
                return _Objectspooled[i];

            }
        }
        //if all are active ,create new one
        int _random = Random.Range(0, pooledobject.Length);
        GameObject obj = (GameObject)Instantiate(pooledobject[_random]);
        obj.SetActive(false);
        _Objectspooled.Add(obj);
        return obj;
    }   
}

