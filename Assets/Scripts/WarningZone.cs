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
            Debug.Log("Ÿ�̸� ����!");
            Invoke("GameOverTimer", gameOverTriggerTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            // ���� ���� �� �Ʒ��� ���� ���� ���ӿ��� ó������ Ÿ�̸� ����
            float lastCollisionPosition = collision.transform.position.y;
            float warningZonePosition = transform.position.y;

            if(lastCollisionPosition > warningZonePosition)
            {
                Debug.Log("��� ���ӿ���!!!!");
            }

            CancelInvoke("GameOverTimer");
        }
    }


    // �׽�Ʈ�� �Լ�. ���� ���� �Ŵ���(��������) ������ ���� ���ӿ��� ���� ����.
    void GameOverTimer()
    {
        Debug.Log("���� ����");
    }
}
