using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    //to define the number, names, sizes, and prefabs of the pools
    [SerializeField] private PoolSettings[] poolSettings;
    //the actual pools
    private Dictionary<string,Queue<GameObject>> pools = new();
    
    [Serializable] public class PoolSettings
    {
        public string poolName;
        public int poolSize;
        public GameObject prefab;
    }

    private void Awake()
    {
        InitializePools();
    }

    public void InitializePools()
    {
        foreach (PoolSettings settings in poolSettings)
        {
            string name = settings.poolName;
            int poolSize = settings.poolSize;
            GameObject prefab = settings.prefab;

            Queue<GameObject> newPool = new Queue<GameObject>();
            AddItemsToPool(poolSize, prefab, newPool);
            
            pools.Add(name,newPool);
        }
    }

    private void AddItemsToPool(int numItems, GameObject prefab, Queue<GameObject> pool)
    {
        for (int i = 0; i < numItems; i++)
        {
            GameObject newobj = Instantiate(prefab);
            newobj.SetActive(false);
            pool.Enqueue(newobj);
        }
    }

    public void InsertToPool(string poolName, GameObject obj)
    {
        //deactivates obj and inserts it to the pool named poolName
        
        CheckPoolExists(poolName);
        
        obj.SetActive(false);
        pools[poolName].Enqueue(obj);
    }
    
    public GameObject GetFromPool(string poolName)
    {
        //gets an object from the pool and activates it
        
        CheckPoolExists(poolName);
        Queue<GameObject> pool = pools[poolName];
        
        if (pool.Count <= 0)
        {
            Debug.LogWarning($"Pool {poolName} has ran out of items. Creating more...");
            PoolSettings smallPoolSettings = poolSettings.First(setting => setting.poolName == poolName);
            if (smallPoolSettings.poolSize <= 0) smallPoolSettings.poolSize = 1;
            int currentPoolSize = smallPoolSettings.poolSize;
            AddItemsToPool(currentPoolSize, smallPoolSettings.prefab, pool);
            smallPoolSettings.poolSize *= 2;
        }
        
        GameObject newobj = pool.Dequeue();
        newobj.SetActive(true);
        return newobj;
    }

    private void CheckPoolExists(string poolName)
    {
        if (!pools.ContainsKey(poolName))
        {
            throw new Exception($"There is no pool named {poolName}");
        }
    }
}
