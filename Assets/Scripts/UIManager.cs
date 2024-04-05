using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // UI �Ŵ��� Ž�� �� UIGameObject�� �ʵ� ������ ����.
        if (GameObject.Find("UI").gameObject != null)
        {
            UIGameObject = GameObject.Find("UI");
        }
    }

    #region in Game
    public void UpdateGameScore(int score)
    {
        GameObject scoreTextGameObject = UIGameObject.transform.Find("Score/ScoreNumber").gameObject;

        if(scoreTextGameObject != null)
        {
            TextMeshProUGUI scoreText = scoreTextGameObject.GetComponent<TextMeshProUGUI>();

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }
    #endregion
}
