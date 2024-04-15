using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h = 0;
    public GameObject basket;
    public float speed;

    private float leftBaksetBorder;
    private float rightBaksetBorder;
    private float halfWidthOfPlayer;

    void Start()
    {
        halfWidthOfPlayer = transform.localScale.x / 2;

        if (basket != null)
        {
            Renderer rend = basket.GetComponent<Renderer>();
            rightBaksetBorder = rend.bounds.max.x - halfWidthOfPlayer;
            leftBaksetBorder = rend.bounds.min.x + halfWidthOfPlayer;
        }
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if ((h > 0 && transform.position.x >= rightBaksetBorder) || 
            (h < 0 && transform.position.x <= leftBaksetBorder) || 
            StageManager.Instance.isGameOver ||
            StageManager.Instance.activePlayer == false)
        {
            return;
        }

        transform.Translate(new Vector2(h * speed, 0) * Time.deltaTime);
    }
}
