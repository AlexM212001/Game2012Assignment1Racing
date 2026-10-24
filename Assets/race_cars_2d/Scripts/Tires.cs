using UnityEngine;

public class Tires : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float playerSpeedBoostPerPickup = 0.35f;
    [SerializeField] private float roadSpeedBoostPerPickup = 0.35f;

    private void Update()
    {
        transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovements player = collision.GetComponent<PlayerMovements>();
        if (player == null)
        {
            return;
        }

        player.AddSpeedBoost(playerSpeedBoostPerPickup);

        Road_Movements[] roads = FindObjectsOfType<Road_Movements>();
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i].AddSpeedBoost(roadSpeedBoostPerPickup);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
