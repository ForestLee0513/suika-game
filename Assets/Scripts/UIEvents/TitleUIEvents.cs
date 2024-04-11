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

    // 에셋이 많아져서 로딩이 생긴다면 로딩바 구현 예정. (그 전에 생기지 않는게 좋겠지만..)
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
