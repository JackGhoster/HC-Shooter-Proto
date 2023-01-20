using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    public static ObjectPooler current;

    private List<GameObject> _pooledObjects = new List<GameObject>();
    private int _amountToPool = 10;
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }       
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_bulletPrefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }
}
