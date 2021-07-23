using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour
{
    enemyHealth enemiesHealth;
    public float gunDamage = 1f;
    private void Awake()
    {
        enemiesHealth = GameObject.Find("TestEnemy").GetComponent<enemyHealth>();
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.CompareTag("Enemy") && Input.GetMouseButtonDown(0)) //Shoots
            {
                enemyHealth health = hit.collider.GetComponent<enemyHealth>();
                if (health != null)
                {
                    health.Damage(gunDamage);
                }
            }
        }
    }
}
