using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPrefabManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs = new GameObject[8];
    private List<GameObject> fruitQueue = new List<GameObject>();
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

    public bool AddFruitQueue(GameObject fruit)
    {
        fruitQueue.Add(fruit);
        if(fruitQueue.Count < 2)
        {
            return false;
        }

        fruitQueue.Clear();
        return true;
    }

    public GameObject GetNextGenerateFruit(int fruitIndex)
    {
        if (fruitIndex + 1 >= fruitPrefabs.Length)
        {
            return null;
        }

        Debug.Log(fruitIndex + 1);

        return fruitPrefabs[fruitIndex + 1];
    }
}
