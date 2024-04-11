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
    }
}
