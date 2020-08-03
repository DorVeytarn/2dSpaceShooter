using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, _container.transform);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            for (int j = 0; j < prefabs.Length - 1; j++)
            {
                GameObject necessarilySpawnedObject = Instantiate(prefabs[j], _container.transform);
                necessarilySpawnedObject.SetActive(false);

                _pool.Add(necessarilySpawnedObject);
            }
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawnedObject = Instantiate(prefabs[randomIndex], _container.transform);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(spawnedObj => spawnedObj.activeSelf == false);

        return result != null;
    }
}
