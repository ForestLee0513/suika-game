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

    // ������ �������� �ε��� ����ٸ� �ε��� ���� ����. (�� ���� ������ �ʴ°� ��������..)
    IEnumerator LoadInGameAsync(int sceneIndex)
    {
        AsyncOperation nextScene = SceneManager.LoadSceneAsync(sceneIndex);

        // load per frame;
        while (!nextScene.isDone)
        {
            yield return null;
        }
    }

    // �ε� ���� �ٸ� �� �ε� �ڷ�ƾ�� �ҷ����� ���� �����ϱ� ���� ��ư ��Ȱ��ȭ ó��.
    private void DisableAllButtons()
    {
        foreach (Button button in allButtonsInScene)
        {
            button.enabled = false;
        }
    }
}
