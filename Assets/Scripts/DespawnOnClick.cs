using System;
using UnityEngine;

public class DespawnOnClick : ObjectPoolInterface
{
    private void OnMouseDown()
    {
        objectPoolManager.InsertToPool(poolName, this.gameObject);
    }
}
