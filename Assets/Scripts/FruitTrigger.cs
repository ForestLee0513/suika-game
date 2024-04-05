using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTrigger : MonoBehaviour
{
    public float cooltime = 1.0f;
    bool isDropped = false;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isDropped == false)
        {
            StartCoroutine("DropFruit");
        }
    }

    IEnumerator DropFruit()
    {
        GameObject nextFruit = StageManager.Instance.GetNextFruit();
        Instantiate(nextFruit, transform.position, Quaternion.identity);

        StageManager.Instance.ChangeNextFruitIndex();
        GameObject changedNextFruit = StageManager.Instance.GetNextFruit();
        transform.parent.GetComponentInChildren<NextFruitSpriteChanger>().SwapSprite(changedNextFruit);

        isDropped = true;
        yield return new WaitForSeconds(cooltime);
        isDropped = false;
    }
}
