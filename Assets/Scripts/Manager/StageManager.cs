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
    public bool isGameOver = false;
    
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ChangeNextFruitIndex();
    }

    public void ChangeNextFruitIndex()
    {
        int totalFruits = FruitPrefabManager.Instance.fruitPrefabs.Length;
        // 0에서 총 과일의 절반 수 사이의 다음 과일을 무작위 선택
        randomRange = Random.Range(0, totalFruits / 2);
    }

    public GameObject GetNextFruit()
    {
        return FruitPrefabManager.Instance.fruitPrefabs[randomRange];
    }

    public void AddScore(int scoreFromFruit)
    {
        score += scoreFromFruit;
        InGameUIManager.Instance.UpdateGameScore(score);
    }

    public void ToggleGameOverState()
    {
        isGameOver = !isGameOver;
        InGameUIManager.Instance.ToggleGameOver();
    }
}
