using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coin;
    public GameObject quad;
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
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenx, screeny;
        Vector2 pos;

        randomItem = Random.Range(0, 1);
        toSpawn = coin;

        screenx = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screeny = Random.Range(c.bounds.min.y, c.bounds.max.y);
        pos = new Vector2(screenx, screeny);

        Instantiate(toSpawn, pos, toSpawn.transform.rotation);
    }
    


    // Update is called once per frame
    void Update()
    {
       //spawnObject();
       
    }
}
