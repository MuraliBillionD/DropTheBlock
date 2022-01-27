using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    public ColorPalettes[] Color_palettes;

    public Material _material;

    [SerializeField]
    private GameObject _wallPrefab;
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private GameObject _ball;
    
    private Vector3 ColorPanel;
    private float scorecount;
    private float difference;

    public Camera cam;
    public int ran;

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
        ran = 0;

        //RESETING EVERYTIME WHEN THE LEVEL LOADS
        LevelLoader.instance.Resetloading();

    }

public void RandomPalete()
    {
        ran++;
        if (ran >= Color_palettes.Length)
        {
            ran = 0;
        }
    }
    /// <summary>
    /// function responsible for giving the color to mesh
    /// </summary>
    /// <param name="mesh"></param>

    public void ColorMesh(Mesh mesh,float f)
    {
        Vector3[] vertices = mesh.vertices;
        Color32[] colors = new Color32[vertices.Length];

        float time = Mathf.Sin(f*0.0125f);
        

        for(int i=0;i<vertices.Length;i++)
        {

            colors[i] = Lerp4(Color_palettes[ran]. GameColors[0], Color_palettes[ran].GameColors[1], Color_palettes[ran].GameColors[2], Color_palettes[ran].GameColors[3],time);
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
      if(timer<0.25f)
        {
            cam.backgroundColor= Color.Lerp(a, b, timer / 0.25f);
            return Color.Lerp(a, b, timer / 0.25f);
        }
        else if (timer < 0.50f)
        {
            cam.backgroundColor = Color.Lerp(b ,c, (timer - 0.25f) / 0.25f);
            return Color.Lerp(b, c, (timer -0.25f)/ 0.25f);
        }
        else if (timer < 0.75f)
        {
            cam.backgroundColor = Color.Lerp(c, d, (timer - 0.50f) / 0.50f);
            return Color.Lerp(c, d, (timer - 0.50f) / 0.50f);
        }
        else
       {
            cam.backgroundColor = Color.Lerp(d, a, (timer - 0.75f) / 0.75f);
            return Color.Lerp(d, a, (timer - 0.75f) / 0.75f);
       }
    }


    private Color32 LerpColors(Color32 a, Color32 b, Color32 c,float timer)
    {
        if (timer < 0.95f)
        {
            cam.backgroundColor = Color.Lerp(a, b, timer / 0.95f);
            return Color.Lerp(a, b, timer / 0.95f);
        }
        else
        {
            timer = 0f;
            cam.backgroundColor = Color.Lerp(b, c, timer / 0.95f);
            return Color.Lerp(a, b, timer / 0.95f);
        }
    }

}
[System.Serializable]
public class ColorPalettes
{
    public Color32[] GameColors;

}
