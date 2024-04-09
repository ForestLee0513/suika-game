using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIEvents : MonoBehaviour
{
    public void MoveToInGame()
    {
        SceneManager.LoadScene(1);
    }
}
