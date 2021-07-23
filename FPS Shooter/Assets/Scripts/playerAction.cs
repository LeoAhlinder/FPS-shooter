using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour
{
    enemyHealth enemiesHealth;
    public float gunDamage = 1f;
    Weapon weapon;
    float TimeBetweenShots = 0.3f;
    bool canFire = true;
    public AudioSource pistol1Shoot;
    private void Awake()
    {
        weapon = GameObject.Find("WeaponScript").GetComponent<Weapon>();
        enemiesHealth = GameObject.Find("TestEnemy").GetComponent<enemyHealth>();
    }
    void Update()
    {

        if (weapon.pistol1)
        {
            TimeBetweenShots = 0.3f;
        }
        else if (weapon.Rifle2)
        {
            TimeBetweenShots = 0.2f;
        }
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.CompareTag("Enemy") && Input.GetMouseButtonDown(0) && canFire) //Shoots
            {
                if (weapon.pistol1) { pistol1Shoot.Play(); }
                Debug.Log("Shooting");
                StartCoroutine(Shot());
                IEnumerator Shot()
                {
                    canFire = false;
                    yield return new WaitForSeconds(TimeBetweenShots);
                    canFire = true;
                }
                enemyHealth health = hit.collider.GetComponent<enemyHealth>();
                if (health != null)
                {
                    health.Damage(gunDamage);
                }
            }
        }
    }
}
