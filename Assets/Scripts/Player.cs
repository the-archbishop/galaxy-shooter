using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private int _lives = 3;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _fireCooldown = 0.0f;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if (_spawnManager)
        {
            Debug.LogError("Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _fireCooldown)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        // Move player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Player Y-axis boundaries
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        // Player position wrapping on X-axis
        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _fireCooldown = Time.time + _fireRate;

        Vector3 laserSpawnPosition = new Vector3(transform.position.x, transform.position.y + 0.8f, 0);
        Instantiate(_laserPrefab, laserSpawnPosition, Quaternion.identity);
    }

    public void Damage()
    {
        _lives -= 1;

        if (_lives < 1)
        {
            // Communicate with Spawn Manager to stop spawning enemies
            _spawnManager.StopSpawn();

            // Destroy player
            Destroy(this.gameObject);
        }
    }
}
