using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public GameObject[] weapons;
    public GameObject weaponHere;
    public GameObject player;
    public GameObject floatingText;
    // Start is called before the first frame update
    void Start()
    {
        //weaponHere = weapons[Random.Range(0, weapons.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        weaponHere = weapons[Random.Range(0, weapons.Length)];
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Coin")
        {
            //weaponHere.transform.parent = player.transform;
           // Instantiate(weaponHere, transform.position, transform.rotation);

            //GameObject newWeapon = Instantiate(weaponHere, transform.position, Quaternion.identity);
            GameObject newWeapon = Instantiate(weaponHere);
            GameObject text = Instantiate(floatingText, transform.position, Quaternion.identity) as GameObject;
            string weaponName = newWeapon.name;
            weaponName = weaponName.Replace("(Clone)","");
            text.transform.GetComponent<TextMesh>().text = weaponName;
            newWeapon.transform.parent = player.transform;
            newWeapon.transform.localPosition = new Vector3(.3f, 0, 0);
            newWeapon.transform.eulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);


        }
    }
    
}
