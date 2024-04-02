using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int randomRange = 0;
    
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            return instance;
        }
    }

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ChangeNextFruit();
    }

    public void ChangeNextFruit()
    {
        int totalFruits = FruitPrefabManager.Instance.fruitPrefabs.Length;
        // 0���� �� ������ ���� ������ ���� ������ ������ ����
        randomRange = Random.Range(0, totalFruits / 2);
    }

    public int GetNextFruit()
    {
        return randomRange;
    }

    public void AddScore(int scoreFromFruit)
    {
        score += scoreFromFruit;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
