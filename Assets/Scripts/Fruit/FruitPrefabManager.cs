using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPrefabManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs = new GameObject[8];
    private static FruitPrefabManager instance; 
    public static FruitPrefabManager Instance 
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
