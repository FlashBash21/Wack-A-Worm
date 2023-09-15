using UnityEngine;
using TMPro;

public class ObjectRandomizer : MonoBehaviour
{
    public GameObject[] objectsToRandomize;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro - Text component to display the score
    public float randomizationInterval = 5f; // Interval in seconds
    public int scoreIncrement = 5000; // Amount to increment the score by
    private float timer = 0f;
    private int currentIndex = -1; // Index of the currently enabled object
    private int score = 0;

    private void Start()
    {
        // Disable all objects at the start
        DisableAllObjects();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= randomizationInterval)
        {
            RandomizeObjects();
            timer = 0f; // Reset the timer
        }

        // Check for player click
        if (Input.GetMouseButtonDown(0) && currentIndex != -1)
        {
            DisableCurrentObject();
        }
    }

    private void RandomizeObjects()
    {
        // Disable all objects
        DisableAllObjects();

        // Randomly select a new object to enable
        int newIndex = Random.Range(0, objectsToRandomize.Length);
        objectsToRandomize[newIndex].SetActive(true);
        currentIndex = newIndex;
    }

    private void DisableAllObjects()
    {
        foreach (GameObject obj in objectsToRandomize)
        {
            obj.SetActive(false);
        }
        currentIndex = -1;
    }

    private void DisableCurrentObject()
    {
        if (currentIndex != -1)
        {
            objectsToRandomize[currentIndex].SetActive(false);
            currentIndex = -1;
            // Wait for 1 second before starting the next randomization
            timer = randomizationInterval - 1f;

            // Increment the score
            score += scoreIncrement;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    // Method to manually add objects to the objectsToRandomize array
    public void AddObject(GameObject obj)
    {
        // Check if the object is already in the array
        if (System.Array.IndexOf(objectsToRandomize, obj) == -1)
        {
            // Add the object to the array
            System.Array.Resize(ref objectsToRandomize, objectsToRandomize.Length + 1);
            objectsToRandomize[objectsToRandomize.Length - 1] = obj;
        }
    }
}
