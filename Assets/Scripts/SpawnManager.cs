using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomX = Random.Range(-8.0f, 8.0f);
            Vector3 enemySpawnPosition = new Vector3(randomX, 8.0f, 0);
            Instantiate(_enemyPrefab, enemySpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
