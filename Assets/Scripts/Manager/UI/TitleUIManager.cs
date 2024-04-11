using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    public void MoveToInGame()
    {
        StartCoroutine(UIManager.Instance.LoadSceneAsyncCoroutine(1));
    }

    public void MoveToLeaderboard()
    {
        StartCoroutine(UIManager.Instance.LoadSceneAsyncCoroutine(2));
    }
}
