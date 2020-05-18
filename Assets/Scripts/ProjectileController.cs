using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float speed;
    public bool dies = true;
    public float lifeTime;
    public float damage;
    public GameObject destroyEffect;
    private Rigidbody2D rb;


 
    void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        Invoke("DestroyProjectile", lifeTime);
        rb = GetComponent<Rigidbody2D>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dies == true)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
       // rb.velocity = new Vector2(speed, velY);

    }

    void DestroyProjectile()
    {
       // Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    

}
