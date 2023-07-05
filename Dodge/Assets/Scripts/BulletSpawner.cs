using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform bulletPool = default;
    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;



    
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerControler>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if ( timeAfterSpawn >= spawnRate )
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, 
                transform.position, transform.rotation, bulletPool);
            bullet.transform.LookAt(target);
            this.transform.LookAt(target);


            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }


    }
}
    // Update is called once per frame

