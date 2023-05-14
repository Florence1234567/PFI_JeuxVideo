using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolComponent : MonoBehaviour
{
    private List<GameObject> pool = new List<GameObject>();

    [SerializeField] GameObject[] ObjectsToPool;
    [SerializeField] float poolCount = 10;

    public static ObjectPoolComponent ObjectPoolInstance;
    GameObject poolObject;

    private void Awake()
    {
        if (ObjectPoolInstance == null)
            ObjectPoolInstance = this;

        poolObject = GameObject.FindWithTag("PoolObject");
    }

    void Start()
    {
        for (int i = 0; i < Mathf.Min(ObjectsToPool.Length, poolCount); i++)
            for (int j = 0; j < poolCount; j++)
            {
                GameObject obj = Instantiate(ObjectsToPool[i]);
                obj.name = ObjectsToPool[i].name;
                obj.transform.SetParent(poolObject.transform, true);
                obj.SetActive(false);
                pool.Add(obj);
            }
    }

    public GameObject GetPooledObject(GameObject typeObject)
    {
        for (int i = 0; i < pool.Count; i++)
            if (!pool[i].activeInHierarchy && pool[i].name == typeObject.name)
                return pool[i];

        return null;
    }
}