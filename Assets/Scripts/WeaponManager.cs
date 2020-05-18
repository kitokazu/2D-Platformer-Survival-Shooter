using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject activeWeapon;
    Weapon wpn;

    // Start is called before the first frame update
    void Start()
    {
        wpn = activeWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWeapon(GameObject weapon)
    {
        activeWeapon = weapon;
        wpn = activeWeapon.GetComponent<Weapon>();
    }
}
