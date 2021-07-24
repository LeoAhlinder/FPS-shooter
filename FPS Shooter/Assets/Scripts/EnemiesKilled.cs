using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesKilled : MonoBehaviour
{
    TextMeshProUGUI TM;
    float EK;//Enemieskilled
    enemyHealth eH;
    Weapon W;
    private void Awake()
    {
        W = GameObject.Find("WeaponScript").GetComponent<Weapon>();
        TM = gameObject.GetComponent<TextMeshProUGUI>();
        eH = GameObject.Find("TestEnemy").GetComponent<enemyHealth>();
    }

    void Update()
    {
        EK = eH.EnemiesKilled;
        TM.text = "" + EK;

        if (eH.EnemiesKilled >= 10)
        {
            W.pistol1 = false;
            W.Rifle2 = true;
        }
    }
}
