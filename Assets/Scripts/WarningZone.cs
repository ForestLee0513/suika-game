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
            Debug.Log("Ÿ�̸� ����!");
            Invoke("GameOverTimer", gameOverTriggerTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            Debug.Log("Ÿ�̸� ����");
            CancelInvoke("GameOverTimer");
        }
    }


    // �׽�Ʈ�� �Լ�. ���� ���� �Ŵ��� ������ ���� ���ӿ��� ���� ����.
    void GameOverTimer()
    {
        Debug.Log("���� ����");
    }
}
