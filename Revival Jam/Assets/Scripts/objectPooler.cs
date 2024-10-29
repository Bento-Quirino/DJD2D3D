using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<T> where T : MonoBehaviour
{
    private List<T> pool;
    private T prefab;
    private Transform parent;

    public ObjectPooler(T prefab, int initialSize, Vector3 initialPosition, bool active, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;
        pool = new List<T>();

        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab, initialPosition, Quaternion.identity, parent);
            obj.gameObject.SetActive(active);
            pool.Add(obj);
        }
    }

    public T GetObject()
    {
        foreach (T obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        T newObj = Object.Instantiate(prefab, parent);
        pool.Add(newObj);
        newObj.gameObject.SetActive(true);
        return newObj;
    }


    public List<T> GetPool()
    {
        return pool;
    }
}
