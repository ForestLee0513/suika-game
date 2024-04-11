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

    // dialog ���� ���� ����

    // �񵿱� �� �ε�
    // ������ �������� �ε��� ����ٸ� �ε��� ���� ����. (�� ���� ������ �ʴ°� ��������..)
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
