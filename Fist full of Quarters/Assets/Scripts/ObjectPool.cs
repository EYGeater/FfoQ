using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectType;
    public int maxObjectCount;
    private GameObject[] objects;

    private void Start()
    {
        objects = new GameObject[maxObjectCount];
        for(int i = 0; i < objects.Length; i++)
        {
            GameObject tmp = Instantiate(objectType);
            tmp.SetActive(false);
            objects[i] = tmp;
        }
    }

    public GameObject PullFromPool()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if(!objects[i].activeInHierarchy) return objects[i];
        }

        Debug.LogWarning("Limited by object pool");
        return null;
    }
}
