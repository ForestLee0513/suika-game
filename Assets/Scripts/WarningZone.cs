using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZone : MonoBehaviour
{
    public float gameOverTriggerTime = 2.0f;
    private bool isTimerStart = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit" && isTimerStart == false && StageManager.Instance.isGameOver == false)
        {
            isTimerStart = true;
            Debug.Log("타이머 시작!");
            Invoke("ToggleGameOverInvoke", gameOverTriggerTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fruit" && StageManager.Instance.isGameOver == false)
        {
            isTimerStart = false;
            CancelInvoke("ToggleGameOverInvoke");

            float lastCollisionPosition = collision.transform.position.y;
            float warningZonePosition = transform.position.y;

            if(lastCollisionPosition > warningZonePosition)
            {
                StageManager.Instance.ToggleGameOver();
            }
        }
    }

    void ToggleGameOverInvoke()
    {
        StageManager.Instance.ToggleGameOver();
    }
}
