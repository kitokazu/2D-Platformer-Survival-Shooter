using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Collision2D collision;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", spawnTime, spawnDelay);
        spawnObject();
    }


    public void spawnObject()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }



    // Update is called once per frame
    void Update()
    {
        //spawnObject();

    }
}
