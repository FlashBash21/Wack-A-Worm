using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject wormPrefab;
    public GameObject[] spawnedWorms;


    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;

        for (int i = 0; i > 9; i++)
        {
            spawnedWorms[i] = Instantiate(wormPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
