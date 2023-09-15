using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
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

        float startY = UnityEngine.Random.Range(startPos.y - 6f, startPos.y + 4f);
        cloud.transform.position = new Vector3 (startPos.x, startY, startPos.z);

        float scale = UnityEngine.Random.Range(2.5f, 4f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = UnityEngine.Random.Range(0.9f, 1.2f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);

    }

    void AttemptSpawn()
    {
        //check some things.
        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 4);
            SpawnCloud(spawnPos);

        }

    }

}
