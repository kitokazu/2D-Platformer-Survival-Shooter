using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public AudioClip explode;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(explode, transform.position);
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
