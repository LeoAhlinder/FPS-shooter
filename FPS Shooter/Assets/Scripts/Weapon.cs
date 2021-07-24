using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{       
    public bool Rifle2 = false;
    public bool pistol1 = true;

    public GameObject Pistol1GO;
    public GameObject akGO;
    void Update()
    {
       if (pistol1)
       {
            Pistol1GO.SetActive(true);
       }
       else
       {
            Pistol1GO.SetActive(false);
       }
       if (Rifle2)
       {
            akGO.SetActive(true);
       }
       else
       {
            akGO.SetActive(false);
       }
    }
}
