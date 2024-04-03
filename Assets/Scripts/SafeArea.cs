using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Debug.Log("GameOver!");
        }
    }
}
