using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZone : MonoBehaviour
{
    public float gameOverTriggerTime = 2.0f;

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
            // 방향 감지 후 아래로 갔을 때만 게임오버 처리없이 타이머 종료
            float lastCollisionPosition = collision.transform.position.y;
            float warningZonePosition = transform.position.y;

            if(lastCollisionPosition > warningZonePosition)
            {
                Debug.Log("즉시 게임오버!!!!");
            }

            CancelInvoke("GameOverTimer");
        }
    }


    // 테스트용 함수. 추후 게임 매니저(스테이지) 등으로 통해 게임오버 제어 예정.
    void GameOverTimer()
    {
        Debug.Log("게임 오버");
    }
}
