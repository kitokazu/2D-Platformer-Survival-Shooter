using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    public Animator animator;
    public AudioClip hit;
    public AudioClip gameOver;
    private bool movingRight;
    float horizontalMove = 0f;
    public float speed;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Bullet")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            TakeDamage(1f);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "ShotgunBullet")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            TakeDamage(1f);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Magic")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            TakeDamage(2f);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Explosion")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            TakeDamage(99f);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            AudioSource.PlayClipAtPoint(gameOver, transform.position);
            Destroy(collision.gameObject);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "EnemyTurnLeft")
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if (LayerMask.LayerToName(collision.gameObject.layer) == "EnemyTurnRight")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);



        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (Camera.main.WorldToViewportPoint(transform.position).y < -1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
