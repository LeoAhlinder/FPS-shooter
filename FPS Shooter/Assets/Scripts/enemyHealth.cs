using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health = 3f;
    public float EnemiesKilled = 0;
    // Update is called once per frame

    public void Damage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            EnemiesKilled = 10f;
            Destroy(gameObject);
        }
    }

 
}

