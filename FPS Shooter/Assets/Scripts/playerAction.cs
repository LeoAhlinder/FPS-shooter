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
    float MagSize = 18f;

    public AudioSource pistol1Shoot;
    public AudioSource pistol1Reload;
    public AudioSource akReloadSound;
    public AudioSource akShootSound;
    private void Awake()
    {
        weapon = GameObject.Find("WeaponScript").GetComponent<Weapon>();
        enemiesHealth = GameObject.Find("TestEnemy").GetComponent<enemyHealth>();
    }
    void Update()
    {
        IEnumerator Reload()
        {
            Debug.Log("321");
            if (weapon.pistol1)
            {
                yield return new WaitForSeconds(3f);
                MagSize = 18f;
                canFire = true;
            }
            if (weapon.akGO)
            {
                yield return new WaitForSeconds(4f);
                MagSize = 30f;
                canFire = true;
            }
        }
        IEnumerator Shot()
        {
            Debug.Log("shot");
            MagSize--;
            canFire = false;
            yield return new WaitForSeconds(TimeBetweenShots);
            canFire = true;
        }

        if (weapon.pistol1)
        {
            TimeBetweenShots = 0.3f;
            gunDamage = 1f;
        }
        else if (weapon.Rifle2)
        {
            gunDamage = 2f;
            TimeBetweenShots = 0.2f;
        }
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit))
        {
            if (Input.GetMouseButtonDown(0) && canFire && MagSize > 0) //Shoots
            {
                if (weapon.pistol1) { pistol1Shoot.Play(); }
                StartCoroutine(Shot());             
                enemyHealth health = hit.collider.GetComponent<enemyHealth>();
                if (health != null)
                {
                    health.Damage(gunDamage);
                }
            }
            if (MagSize <= 0 && Input.GetKeyDown(KeyCode.R))
            {
                if (weapon.pistol1) { pistol1Reload.Play(); }
                canFire = false;
                StartCoroutine(Reload());
            }
        }
    }
}
