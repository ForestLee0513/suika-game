using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIEvents : MonoBehaviour
{
    public void MoveToInGame()
    {
        StartCoroutine(nameof(LoadInGameAsync));
    }

    // ������ �������� �ε��� ����ٸ� �ε��� ���� ����. (�� ���� ������ �ʴ°� ��������..)
    IEnumerator LoadInGameAsync()
    {
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(1);

        // load per frame;
        while (!nextScene.isDone)
        {
            yield return null;
        }
    }
}
