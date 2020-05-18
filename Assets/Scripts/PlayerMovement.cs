using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; // give access to animator and parameters


    public float runSpeed = 25f;
    public bool hasJumpPotion = false; //does the player have a Jump Potion
    public bool hasSpeedPotion = false;
    public int potionModAmount = 0;

 
    public AudioClip jumpClip;
    public AudioClip shootClip;
    public AudioClip deathClip;
    public GameObject projectile;
    public Transform firePoint;
    public GameManager gameManager;

    private float potionTimeMax = 10f;
    private float potionTimeCur = 0f;

    float horizontalMove = 0f;
    bool jumpFlag = false;
    bool jump = false;



    // Update is called once per frame
    void Update()
    {
        //Usually checking for collisions and inputs
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //Absolute value because moving to the left will give negative movement

        if (jumpFlag)
        {
            jumpFlag = false;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Jump")) //Mapped to the spacebar in Unity
        {
            if (animator.GetBool("IsJumping") == false)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                jump = true;
                animator.SetBool("IsJumping", true);
            }
           
        }
        if (Camera.main.WorldToViewportPoint(transform.position).y < -1)
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(this.gameObject);
            gameManager.EndGame();
           // FindObjectOfType<GameManager>().EndGame();
            
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(this.gameObject);
            gameManager.EndGame();
           // FindObjectOfType<GameManager>().EndGame();
        }


    }

    void pickUp()
    {

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        jump = false;
    }

    void FixedUpdate()
    {
        if (hasJumpPotion && potionTimeCur < potionTimeMax) // If jump potion is true and time is less than max
        {
            controller.m_JumpForceMod = potionModAmount;
            potionTimeCur += Time.fixedDeltaTime;
        }
        else
        {
            potionTimeCur = 0f;
            controller.m_JumpForceMod = 0;
            hasJumpPotion = false;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);   
        
        if (jump)
        {
            jumpFlag = true;
        }


    }
}
