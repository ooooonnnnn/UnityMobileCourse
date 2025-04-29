using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<string,Queue<GameObject>> pools = new();
    private Dictionary<string,int> poolSizes;
    [SerializeField] private GameObject prefab;
    
    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newobj = Instantiate(prefab);
            newobj.SetActive(false);
            pool.Enqueue(newobj);
        }
    }
    
    public void InsertToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public GameObject GetFromPool()
    {
        GameObject newobj = pool.Dequeue();
        newobj.SetActive(true);
        return newobj;
    }
}
