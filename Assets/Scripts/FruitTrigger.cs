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
        StageManager.Instance.ChangeNextFruit();
        int nextFruitIndex = StageManager.Instance.GetNextFruit();
        GameObject nextFruit = FruitPrefabManager.Instance.fruitPrefabs[nextFruitIndex];
        Instantiate(nextFruit, transform.position, Quaternion.identity);

        isDropped = true;
        yield return new WaitForSeconds(cooltime);
        isDropped = false;
    }
}
