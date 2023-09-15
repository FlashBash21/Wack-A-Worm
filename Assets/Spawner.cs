using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public const int NUM_WORMS = 9;
    public const float WORM_OFFSET = 3.5f;

    public GameObject wormPrefab;
    public GameObject[] spawnedWorms;


    // Start is called before the first frame update
    void Start()
    {

        spawnedWorms = new GameObject[NUM_WORMS];

        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        //horizontalMin = -halfWidth;
        //horizontalMax = halfWidth;

        for (int i = 0, j = 0; i < NUM_WORMS; i++)
        {
            //calculate the position to spawn the worm in
            if ((i) % 3 == 0) j++;
            float x_offset = -WORM_OFFSET + ((i + 1) % 3 * WORM_OFFSET);
            float y_offset = -WORM_OFFSET * 2 + j * WORM_OFFSET;

            //spawn the worm and translate to the proper position
            spawnedWorms[i] = Instantiate(wormPrefab);
            spawnedWorms[i].transform.Translate(x_offset, y_offset, 0);

            Debug.Log("Spawned a Worm " + i + " at position (" + x_offset + ", " + y_offset + ")");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
