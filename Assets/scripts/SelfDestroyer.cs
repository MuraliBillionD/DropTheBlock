using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelfDestroyer : MonoBehaviour
{
    private GameObject destructionpoint;
  //  private Material _thisMaterial;

    void Start()
    {
        destructionpoint = GameObject.Find("PlatformDestructionpoint");
       // _thisMaterial = GetComponentInChildren<Material>();

      
    }
    private void OnEnable()
    {
        Animate();
    }

    void Update()
    {
        if (transform.position.y< destructionpoint.transform.position.y)
        {

            Playercontroller.instance.RemoveFromList(this.gameObject);
        }
  
    }

    public  void Animate()
    {
        transform.DOMoveY(transform.position.y-10,0.2f);
    }
}
