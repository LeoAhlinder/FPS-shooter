using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesKilled : MonoBehaviour
{
    TextMeshProUGUI TM;
    float EK;//Enemieskilled
    enemyHealth eH;
    private void Awake()
    {
        TM = gameObject.GetComponent<TextMeshProUGUI>();
        eH = GameObject.Find("TestEnemy").GetComponent<enemyHealth>();
    }

    void Update()
    {
        EK = eH.EnemiesKilled;
        TM.text = "" + EK;
    }
}
