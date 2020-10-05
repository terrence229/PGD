using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flockspawner : MonoBehaviour
{
    public Transform[] flockSpawnPoints;
    public GameObject Bird_Particle;
    //Rigidbody rb;
    int randomSpawnPoint;
    public static bool spawnAllowed;
    float newTime;

    void Start()
    {
        newTime = Time.time + 20;
        GameObject Bird = (Bird_Particle);
        Bird.name = "Bird_Particle";    
    }
    void Update()
    {
        if (Time.time >= newTime)
        {
            spawnAllowed = true;
            newTime = Time.time + 40;
        }
        if (spawnAllowed)
        {
            SpawnAFlock();
        }
    }
    void SpawnAFlock()
    {
            randomSpawnPoint = Random.Range(0, flockSpawnPoints.Length);
            GameObject flock = Instantiate(Bird_Particle, flockSpawnPoints[randomSpawnPoint].position, Quaternion.identity);
            flock.transform.rotation = flockSpawnPoints[randomSpawnPoint].rotation;
            flock.GetComponent<UnityEngine.ParticleSystem>().Play();

        spawnAllowed = false;
    }
}
