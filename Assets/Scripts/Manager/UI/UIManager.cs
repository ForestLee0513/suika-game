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
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // dialog 관련 구현 예정

    // 비동기 씬 로드
    // 에셋이 많아져서 로딩이 생긴다면 로딩바 구현 예정. (그 전에 생기지 않는게 좋겠지만..)
    public IEnumerator LoadSceneAsyncCoroutine(int sceneIndex)
    {
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(sceneIndex);

        // load per frame;
        while (!nextScene.isDone)
        {
            yield return null;
        }
    }
}
