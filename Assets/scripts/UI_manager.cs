using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject TapText;

    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private Text _endScore;

    public static UI_manager instance;

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

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        
        _scoreText.text = score.ToString();
    }

    public void Taptext()
    {
        TapText.SetActive(false);
    }

    public void GameOver(bool active,int score)
    {
        _gameOver.SetActive(active);
        _scoreText.gameObject.SetActive(false);
        _endScore.text = "SCORE: "+score.ToString();

        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);

    }

    public void Restart()
    {
        _gameOver.SetActive(false);
        _scoreText.gameObject.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void BackHome()
    {
        _gameOver.SetActive(false);
        _scoreText.gameObject.SetActive(true);
        _scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        TapText.SetActive(true);
        LevelLoader.instance.LoadLevel(0);
    }
}
