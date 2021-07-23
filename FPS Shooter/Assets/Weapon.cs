using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{       
    bool Rifle2 = false;
    bool pistol1 = true;

    public GameObject Pistol1GO;
    public GameObject Rifle2GO;
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
            Rifle2GO.SetActive(true);
       }
       else
       {
            Rifle2GO.SetActive(false);
       }


    }
}
