using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolComponent : MonoBehaviour
{
    [SerializeField] GameObject[] ObjectsToPool;
    [SerializeField] float[] quatityByObjects;

    GameObject poolObject;

    public static ObjectPoolComponent ObjectPoolInstance;
    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        if (ObjectPoolInstance == null)
            ObjectPoolInstance = this;

        poolObject = GameObject.FindWithTag("poolObject");
    }

    void Start()
    {
        float toPoolLength = ObjectsToPool.Length;
        float quantityLength = quatityByObjects.Length;

        for (int i = 0; i < Mathf.Min(toPoolLength, quantityLength); i++)
            for (int j = 0; j < quatityByObjects[i]; j++)
            {
                GameObject obj = Instantiate(ObjectsToPool[i]);
                obj.name = ObjectsToPool[i].name;
                obj.transform.SetParent(poolObject.transform, true);
                obj.SetActive(false);
                pool.Add(obj);
            }
    }

    public GameObject GetPooledObject(GameObject typeObjet)
    {
        float poolCount = pool.Count;

        for (int i = 0; i < poolCount; i++)
            if (!pool[i].activeInHierarchy && pool[i].name == typeObjet.name)
                return pool[i];

        return null; 
    }
}
