using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public Color32[] GameColors;
    public Material _material;
    public float _CheckPoint;



    [SerializeField]
    private GameObject _wallPrefab;
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private GameObject _ball;
    private float _counter;
    private Vector3 ColorPanel;
    private float scorecount;
    private float difference;

    public Camera cam;

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
        _meshRenderer = _wallPrefab.GetComponentInChildren<MeshRenderer>();
        _counter = _CheckPoint;
    }

    private void Update()
    {
         difference = (_CheckPoint - _ball.transform.position.y)/_counter;
        if (_CheckPoint<=_ball.transform.position.y)
        {
            _CheckPoint += _counter;
          
        }
        
    }
    /// <summary>
    /// function responsible for giving the color to mesh
    /// </summary>
    /// <param name="mesh"></param>

    public void ColorMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        Color32[] colors = new Color32[vertices.Length];

        float time = Mathf.Sin(difference);
        

        for(int i=0;i<vertices.Length;i++)
        {

            colors[i] = Lerp4(GameColors[0], GameColors[1], GameColors[2], GameColors[3],time);
        }
        mesh.colors32 = colors;
    }

    /// <summary>
    /// function responsible for lerping  two colors
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <param name="timer"></param>
    /// <returns></returns>
    private Color32 Lerp4(Color32 a, Color32 b, Color32 c, Color32 d,float timer)
    {
      if(timer<0.33f)
        {
            cam.backgroundColor= Color.Lerp(a, b, timer / 0.33f);
            return Color.Lerp(a, b, timer / 0.33f);
        }
        else if (timer < 0.66f)
        {
            cam.backgroundColor = Color.Lerp(b, c, (timer - 0.33f) / 0.33f);
            return Color.Lerp(b, c, (timer -0.33f)/ 0.33f);
        }
      else
       {
            cam.backgroundColor = Color.Lerp(c, d, (timer - 0.66f) / 0.66f);
            return Color.Lerp(c, d, (timer - 0.66f) / 0.66f);
       }
    }
}
