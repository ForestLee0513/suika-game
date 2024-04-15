using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    #region Singleton Field
    private static InGameUIManager instance;
    public static InGameUIManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RestartGame()
    {
        StartCoroutine(UIManager.Instance.LoadSceneAsyncCoroutine(1));
    }

    public void ExitToTitle()
    {
        StartCoroutine(UIManager.Instance.LoadSceneAsyncCoroutine(0));
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        GameObject pauseDialog = transform.Find("Pause").gameObject;
        pauseDialog.SetActive(!pauseDialog.activeSelf);

        if(pauseDialog.activeSelf == true)
        {
            StageManager.Instance.activePlayer = false;
        }
        else
        {
            StageManager.Instance.activePlayer = true;
        }
    }

    public void UpdateGameScore(int score)
    {
        GameObject scoreTextGameObject = transform.Find("Score/ScoreNumber").gameObject;
        if (scoreTextGameObject != null)
        {
            if (scoreTextGameObject.TryGetComponent(out TextMeshProUGUI scoreText))
            {
                scoreText.text = score.ToString();
            }
        }
    }

    public void ToggleGameOver()
    {
        GameObject gameOverScreen = transform.Find("GameOver").gameObject;
        gameOverScreen.SetActive(!gameOverScreen.activeSelf);

        if (gameOverScreen.activeSelf == true)
        {
            StageManager.Instance.activePlayer = false;
        }
        else
        {
            StageManager.Instance.activePlayer = true;
        }
    }

    public void UpdateHighScore(int score)
    {
        TextMeshProUGUI gameOverHighScoreText = transform.Find("GameOver/GameOverDialog/HighScoreGroup/HighScore").GetComponent<TextMeshProUGUI>();
        gameOverHighScoreText.text = score.ToString();
    }

    public void UpdateResultScore(int score)
    {
        TextMeshProUGUI gameOverScoreText = transform.Find("GameOver/GameOverDialog/ScoreGroup/Score").GetComponent<TextMeshProUGUI>();
        gameOverScoreText.text = score.ToString();
    }
}
