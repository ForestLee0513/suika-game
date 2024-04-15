using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private string highScoreJsonPath;
    private HighScore highScoreData;
    [SerializeField]
    private int randomRange = 0;
    public bool isGameOver = false;
    public bool activePlayer = true;

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

        highScoreJsonPath = Path.Combine(Application.dataPath, "highScore.json");
        LoadHighScoreJson();
    }

    void LoadHighScoreJson()
    {
        // 파일이 없을 때
        if (!File.Exists(highScoreJsonPath))
        {
            HighScore newHighScoreData = new HighScore();
            newHighScoreData.name = "Player1";
            newHighScoreData.score = 0;
            SaveHighScoreToJson(newHighScoreData);
            highScoreData = newHighScoreData;
        }
        else
        {
            string loadJson = File.ReadAllText(highScoreJsonPath);
            highScoreData = JsonUtility.FromJson<HighScore>(loadJson);
        }
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

    private void SaveHighScoreToJson(HighScore highScoreData)
    {
        string highScoreJson = JsonUtility.ToJson(highScoreData, true);
        File.WriteAllText(highScoreJsonPath, highScoreJson);
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

        if(isGameOver == true)
        {
            // 최고기록일 때 기록 저장
            if (score >= highScoreData.score)
            {
                highScoreData.score = score;
                SaveHighScoreToJson(highScoreData);
            }

            InGameUIManager.Instance.UpdateHighScore(highScoreData.score);
            InGameUIManager.Instance.UpdateResultScore(score);
        }
    }
}
