using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animate_ball : MonoBehaviour
{
    public float delaytime;
    public float Duration;
    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        //RESETING EVERYTIME WHEN THE LEVEL LOADS
        LevelLoader.instance.Resetloading();
        // Animate();
        transform.DOMoveY(4f, Duration).SetEase(ease).SetDelay(delaytime).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            UI_manager.instance.Taptext();
            LevelLoader.instance.LoadLevel(1);

        }
    }

    private void Animate()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(transform.DOMoveY(4f, Duration).SetEase(ease).SetDelay(1f).SetLoops(-1, LoopType.Yoyo));
         //   .Append(transform.DOMoveZ(4f, Duration).SetEase(ease).SetDelay(5f).SetLoops(5, LoopType.Yoyo));

    }

}
