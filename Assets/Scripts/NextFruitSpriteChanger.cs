using UnityEngine;

public class NextFruitSpriteChanger : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        GameObject nextFruit = StageManager.Instance.GetNextFruit();
        SwapSprite(nextFruit);
    }

    public void SwapSprite(GameObject nextFruit)
    {
        mySpriteRenderer.sprite = nextFruit.GetComponent<SpriteRenderer>().sprite;
        // �÷��� �׽�Ʈ������ ����.
        mySpriteRenderer.color = nextFruit.GetComponent<SpriteRenderer>().color;
    }
}
