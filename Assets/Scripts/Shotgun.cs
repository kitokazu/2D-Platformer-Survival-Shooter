using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public enum Modes
    {
        melee, straight, follow, Throw
    }
    public Sprite sprite;
    public float offset;
    public GameObject projectile;
    public GameObject weapon;
    public Transform shotPoint;
    public AudioClip shoot;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool coin;
    public Modes projectileMode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Coin")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject p1 = Instantiate(projectile, transform.position, transform.rotation);
                GameObject p2 = Instantiate(projectile, transform.position, transform.rotation);
                GameObject p3 = Instantiate(projectile, transform.position, transform.rotation);
                GameObject p4 = Instantiate(projectile, transform.position, transform.rotation);
                GameObject p5 = Instantiate(projectile, transform.position, transform.rotation);
                //p2.transform.eulerAngles = new Vector3(0, transform.localEulerAngles.y, 45);
                p2.transform.Rotate(0,0,10);
                p3.transform.Rotate(0, 0, -10);
                p4.transform.Rotate(0, 0, 5);
                p4.transform.Rotate(0, 0, -5);
                //p2.transform.localPosition = new Vector3(0, .5f, 0);
                AudioSource.PlayClipAtPoint(shoot, transform.position);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}

