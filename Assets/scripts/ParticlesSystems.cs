using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSystems : MonoBehaviour
{
    public static ParticlesSystems instance;
    [SerializeField]
    private ParticleSystem[] particle;

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

    public void HitBounce(Vector3 vector)
    {
       var Obj= Instantiate(particle[0], vector, Quaternion.identity);
        Destroy(Obj.gameObject, 2f);
    }

    public void OnWallHIt(Vector3 vector)
    {
        var Obj = Instantiate(particle[1], vector, Quaternion.identity);
        Destroy(Obj.gameObject, 5f);
    }

    public void HitEnd(Vector3 vector)
    {
        var Obj = Instantiate(particle[2], vector, Quaternion.identity);
        Destroy(Obj.gameObject, 3f);
    }

}

