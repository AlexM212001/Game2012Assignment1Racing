using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] tires; // Array of car prefabs to spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTires());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Tires()
    {
        int randomIndex = Random.Range(0, tires.Length); 
        float randomX = Random.Range(-1.8f, 1.8f); 
        Instantiate(tires[randomIndex], new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator SpawnTires()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f)); 
            Tires(); 
        }
    }
}
