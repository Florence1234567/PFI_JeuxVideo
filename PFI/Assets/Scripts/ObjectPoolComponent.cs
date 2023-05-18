using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolComponent : MonoBehaviour
{
    private List<GameObject> pool = new List<GameObject>();

    [SerializeField] GameObject[] ObjectsToPool;
    [SerializeField] float[] quantiteParObjet;

    public static ObjectPoolComponent ObjectPoolinstance;

    private void Awake()
    {
        if (ObjectPoolinstance == null)
            ObjectPoolinstance = this;
    }

    void Start()
    {
        for(int i = 0; i < Mathf.Min(ObjectsToPool.Length,quantiteParObjet.Length); i++)
            for (int o = 0; o < quantiteParObjet[i]; o++)
            {
                GameObject obj = Instantiate(ObjectsToPool[i]);
                obj.name = ObjectsToPool[i].name;
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                pool.Add(obj);
            }
    }

    public GameObject GetPooledObject(GameObject typeObjet)
    {
        for (int i = 0; i < pool.Count; i++)
         {
            if (!pool[i].activeInHierarchy && pool[i].name == typeObjet.name)
            {
                return pool[i];
            }
         }
         return null; 
    }
}
