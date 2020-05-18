using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemstonePickup : MonoBehaviour
{
    public AudioClip pickupClip;
    public Boolean pickUp = false;
    private Text scoreText;


    void Start()
    {
        Destroy(gameObject, 10f);
       scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            Destroy(this.gameObject);
            scoreText.GetComponent<ScoreController>().score += 1;
            scoreText.GetComponent<ScoreController>().UpdateScore();



        }
    }
}
