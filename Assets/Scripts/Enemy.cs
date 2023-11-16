using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        // TODO: Respawn at top with new random x position after off-screen
        if (transform.position.y < -5.5f)
        {
            float randomX = Random.Range(-8.0f, 8.0f);
            transform.position = new Vector3(randomX, 8.0f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            // Damage the player and destroy the enemy
            // TODO: Damage the player
            Destroy(this.gameObject);
        }
        else if (other.transform.name.Contains("Laser"))
        {
            // Destroy the laser and the enemy
            Destroy(other.transform.gameObject);
            Destroy(this.gameObject);
        }
    }
}
