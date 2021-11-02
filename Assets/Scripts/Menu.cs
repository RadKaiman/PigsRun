using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public int scoreGeneralAcorns;
    public int saveScore;

    void Start()
    {
        saveScore = PlayerPrefs.GetInt("saveScore");
        Cursor.lockState = CursorLockMode.None;
        if (saveScore == 1)
        {
            scoreGeneralAcorns = PlayerPrefs.GetInt("scoreGeneral");
            scoreGeneralAcorns += PlayerPrefs.GetInt("score");
            scoreText.text = scoreGeneralAcorns.ToString();
            PlayerPrefs.SetInt("scoreGeneral", scoreGeneralAcorns);
            PlayerPrefs.Save();
        }
        else
        {
            scoreGeneralAcorns = PlayerPrefs.GetInt("scoreGeneral");
            scoreText.text = scoreGeneralAcorns.ToString();
            PlayerPrefs.SetInt("scoreGeneral", scoreGeneralAcorns);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        saveScore = 1;
        PlayerPrefs.SetInt("saveScore", saveScore);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.Save();
        scoreGeneralAcorns = 0;
        scoreText.text = scoreGeneralAcorns.ToString();
        PlayerPrefs.SetInt("scoreGeneral", 0);
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        saveScore = 0;
        PlayerPrefs.SetInt("saveScore", saveScore);
        PlayerPrefs.Save();
        Application.Quit();    // закрыть приложение
    }
}
