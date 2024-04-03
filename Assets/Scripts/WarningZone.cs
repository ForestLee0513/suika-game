using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZone : MonoBehaviour
{
    [SerializeField]
    private float durationTime = 0;
    public float gameOverTriggerTime = 2.0f;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            Debug.Log("타이머 시작!");
            Invoke("GameOverTimer", gameOverTriggerTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            Debug.Log("타이머 종료");
            CancelInvoke("GameOverTimer");
        }
    }


    // 테스트용 함수. 추후 게임 매니저 등으로 통해 게임오버 제어 예정.
    void GameOverTimer()
    {
        Debug.Log("게임 오버");
    }
}
