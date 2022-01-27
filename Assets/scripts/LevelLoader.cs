using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    #region Private Members

    [SerializeField]
    private Slider _loadingBar;

    private bool reset;
    #endregion


    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        reset = false;
        Resetloading();
    }

 

    #region public Member Functions
    public void LoadLevel(int scene)
    {
        _loadingBar.value = 0;
        _loadingBar.gameObject.SetActive(true);
        StartCoroutine(LoadAsynchronously(scene));
    }

    /// <summary>
    /// function responsible for reset the Loading Screen
    /// </summary>
    public void Resetloading()
    {
        _loadingBar.value = 0;
        _loadingBar.gameObject.SetActive(false);
    }
    #endregion

    /// <summary>
    /// function responsible for Loading scene Asynchronosly
    /// </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    private IEnumerator LoadAsynchronously(int sceneIndex)
   {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        _loadingBar.gameObject.SetActive(true);

        while (!operation.isDone)
        {          
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _loadingBar.value = progress;
            yield return null;
        }
   }

 

}
