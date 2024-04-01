using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int level;
    public int score;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Fruits collisionFruit = collision.gameObject.GetComponent<Fruits>();
            if (level == collisionFruit.level)
            {
                bool generateTrigger = FruitPrefabManager.Instance.AddFruitQueue(collision.gameObject);
                if (generateTrigger)
                {
                    GameObject nextFruit = FruitPrefabManager.Instance.GetNextGenerateFruit(level);
                    if (nextFruit != null)
                    {
                        Instantiate(nextFruit, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
