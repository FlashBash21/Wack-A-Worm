using UnityEngine;

public class WhackAWorm : MonoBehaviour
{
    public GameObject wormPrefab; // Reference to your worm sprite prefab
    public GameObject[] holes;    // Array of hole prefabs
    public float wormUpDuration = 5f; // How long the worm stays up

    private GameObject currentWorm; // The currently active worm
    private Transform[] holeTransforms; // Transforms of the hole game objects
    private float timer = 0f;

    void Start()
    {
        holeTransforms = new Transform[holes.Length];

        // Get the transforms of the hole game objects
        for (int i = 0; i < holes.Length; i++)
        {
            holeTransforms[i] = holes[i].transform;
        }

        SpawnWorm();
    }

    void SpawnWorm()
    {
        if (currentWorm == null)
        {
            int randomHoleIndex = Random.Range(0, holeTransforms.Length);
            Transform spawnPoint = holeTransforms[randomHoleIndex];
            currentWorm = Instantiate(wormPrefab, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
        else
        {
            // Disable the existing worm and move it to a new hole
            currentWorm.SetActive(false);
            int randomHoleIndex = Random.Range(0, holeTransforms.Length);
            Transform newSpawnPoint = holeTransforms[randomHoleIndex];
            currentWorm.transform.position = newSpawnPoint.position;
            currentWorm.SetActive(true);
        }
    }

    void Update()
    {
        if (currentWorm != null)
        {
            timer += Time.deltaTime;
            if (timer >= wormUpDuration)
            {
                currentWorm.SetActive(false);
                currentWorm = null;
            }
        }
        else
        {
            // Spawn a new worm after a delay
            float spawnDelay = Random.Range(1.0f, 3.0f); // Adjust this delay as needed
            timer += Time.deltaTime;
            if (timer >= spawnDelay)
            {
                SpawnWorm();
            }
        }
    }
}
