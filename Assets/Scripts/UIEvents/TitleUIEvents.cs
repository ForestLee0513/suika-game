using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIEvents : MonoBehaviour
{
    Button[] allButtonsInScene;

    void Start()
    {
        allButtonsInScene = GetComponentsInChildren<Button>();
    }

    public void MoveToInGame()
    {
        DisableAllButtons();
        StartCoroutine(LoadInGameAsync(1));
    }

    public void MoveToLeaderboard()
    {
        DisableAllButtons();
        StartCoroutine(LoadInGameAsync(2));
    }

    // 에셋이 많아져서 로딩이 생긴다면 로딩바 구현 예정. (그 전에 생기지 않는게 좋겠지만..)
    IEnumerator LoadInGameAsync(int sceneIndex)
    {
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(sceneIndex);

        // load per frame;
        while (!nextScene.isDone)
        {
            yield return null;
        }
    }

    // 로딩 도중 다른 씬 로드 코루틴을 불러오는 것을 방지하기 위한 버튼 비활성화 처리.
    private void DisableAllButtons()
    {
        foreach (Button button in allButtonsInScene)
        {
            button.enabled = false;
        }
    }
}
