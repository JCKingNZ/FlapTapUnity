using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{
    // [SerializeField] allows me to link a gameobject or variable from the unity editor to code
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    //creates a new vector called startPos
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {   
        //'Prewarms' the cloud spawning so there are some clouds already spawned when the player starts
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCloud(Vector3 startPos)
    {   
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        //Randomises the spawnposition at which clouds spawn
        float startY = UnityEngine.Random.Range(startPos.y - 6f, startPos.y + 4f);
        cloud.transform.position = new Vector3 (startPos.x, startY, startPos.z);

        //Randomises the scale at which clouds spawn
        float scale = UnityEngine.Random.Range(2.5f, 4f);
        cloud.transform.localScale = new Vector2(scale, scale);

        //Randomises the speed at which clouds spawn
        float speed = UnityEngine.Random.Range(0.9f, 1.2f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);

    }

    void AttemptSpawn()
    {
        //Spawns clouds
        SpawnCloud(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 12; i++)
        {
            Vector3 spawnPos = startPos + Vector3.left * (i * 4);
            SpawnCloud(spawnPos);

        }

    }

}
