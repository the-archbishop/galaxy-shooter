using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawn == false)
        {
            float randomX = Random.Range(-8.0f, 8.0f);
            Vector3 enemySpawnPosition = new Vector3(randomX, 8.0f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, enemySpawnPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void StopSpawn()
    {
        _stopSpawn = true;
    }
}
