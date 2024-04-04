using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int level;
    public int score;
    public bool isMerge;

    Rigidbody2D rb;
    CircleCollider2D circleCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Fruit collisionFruit = collision.gameObject.GetComponent<Fruit>();
            if (level == collisionFruit.level && !isMerge && !collisionFruit.isMerge)
            {
                Vector3 myPosition = transform.position;
                Vector3 collisionFruitPosition = collision.transform.position;

                if(myPosition.y < collisionFruitPosition.y || (myPosition.y == collisionFruitPosition.y && myPosition.x > collisionFruitPosition.x))
                {
                    collisionFruit.Hide(transform.position);
                    if (FruitPrefabManager.Instance.fruitPrefabs.Length > level - 1)
                    {
                        LevelUp();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    public void Hide(Vector3 targetPos)
    {
        isMerge = true;
        rb.simulated = false;
        circleCollider.enabled = false;
        StartCoroutine(HideRoutine(targetPos));
    }

    IEnumerator HideRoutine(Vector3 targetPos)
    {
        int frameCount = 0;

        while (frameCount < 20)
        {
            frameCount++;
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
            yield return null;
        }

        isMerge = false;
        Destroy(gameObject);
    }

    public void LevelUp()
    {
        isMerge = true;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        Destroy(gameObject);
        Instantiate(FruitPrefabManager.Instance.fruitPrefabs[level + 1], transform.position, Quaternion.identity);
    }
}
