using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject prefFabs;
    public Transform ObjectPoolingManager;
    public int amountToPool;
    public virtual void OnDisable()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            pooledObjects[i].SetActive(false);
        }
    }
    public virtual void OnValidate()
    {
        if (ObjectPoolingManager == null) ObjectPoolingManager = transform;
        if (pooledObjects.Count == 0)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(prefFabs, ObjectPoolingManager);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
    public virtual GameObject getObjectPooling(Transform pos = null)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                if (pos != null) pooledObjects[i].transform.position = pos.position;
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        return null;
    }
}