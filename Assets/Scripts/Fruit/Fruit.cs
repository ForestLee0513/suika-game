using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int level;
    public int score;
    public bool isMerge;

    Rigidbody2D rb;
    Collider2D circleCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Fruit collisionFruit = collision.gameObject.GetComponent<Fruit>();
            if (level == collisionFruit.level && !isMerge && !collisionFruit.isMerge)
            {
                Vector3 myPosition = transform.position;
                Vector3 collisionFruitPosition = collision.transform.position;

                if (myPosition.y < collisionFruitPosition.y || (myPosition.y == collisionFruitPosition.y && myPosition.x > collisionFruitPosition.x))
                {
                    collisionFruit.Hide(transform.position);
                    LevelUp();
                }
            }
        }
    }

    public void Hide(Vector3 targetPos)
    {
        isMerge = true;
        rb.simulated = false;
        circleCollider.enabled = false;
        StartCoroutine(HideRoutine(targetPos, 6.0f));
    }

    IEnumerator HideRoutine(Vector3 targetPos, float mergeSpeed)
    {
        float scale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
        float speedAtScale = scale * mergeSpeed;

        while (Vector3.Distance(transform.position, targetPos) > speedAtScale * Time.deltaTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speedAtScale * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMerge = false;

        Destroy(gameObject);
    }

    public void LevelUp()
    {
        isMerge = true;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;

        StageManager.Instance.AddScore(score);
        Destroy(gameObject);
        if(level + 1 < FruitPrefabManager.Instance.fruitPrefabs.Length)
        {
            Instantiate(FruitPrefabManager.Instance.fruitPrefabs[level + 1], transform.position, Quaternion.identity);
        }
    }
}
