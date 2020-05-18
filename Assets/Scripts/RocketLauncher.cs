using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public enum Modes
    {
        melee, straight, follow, Throw
    }
    public Sprite sprite;
    public float offset;
    public GameObject projectile;
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



    public void newWeapon()
    {


    }

    void Update()
    {

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject p1 = Instantiate(projectile, transform.position, transform.rotation);
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
