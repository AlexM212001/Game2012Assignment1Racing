using UnityEngine;
using System.Collections;

public class Car_Spawner : MonoBehaviour
{

    public GameObject[] carPrefabs; // Prefab of the car to spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine(SpawnCars()); // Start the coroutine to spawn cars
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Cars()
    {
        int randomIndex = Random.Range(0, carPrefabs.Length); // Get a random index for the car prefab
        float randomX = Random.Range(-1.8f, 1.8f); // Get a random X position within the range
        Instantiate(carPrefabs[randomIndex], new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f)); // Wait for a random time between 1 and 3 seconds
            Cars(); // Call the Cars() method to spawn a car
        }
    }

   
}
