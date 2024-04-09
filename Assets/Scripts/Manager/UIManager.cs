using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton Field
    private static UIManager instance;
    public static UIManager Instance 
    {
        get
        {
            return instance;
        }
    }
    #endregion

    GameObject UIGameObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (GameObject.Find("UI").gameObject != null)
        {
            UIGameObject = GameObject.Find("UI");
        }
    }

    // dialog 관련 구현 예정

    #region inGame
    public void UpdateGameScore(int score)
    {
        GameObject scoreTextGameObject = UIGameObject.transform.Find("Score/ScoreNumber").gameObject;
        if (scoreTextGameObject != null)
        {
            TextMeshProUGUI scoreText = scoreTextGameObject.GetComponent<TextMeshProUGUI>();

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }

    public void ToggleGameOver()
    {
        GameObject gameOverScreen = UIGameObject.transform.Find("GameOver").gameObject;
        gameOverScreen.SetActive(!gameOverScreen.activeSelf);
    }
    #endregion
}
