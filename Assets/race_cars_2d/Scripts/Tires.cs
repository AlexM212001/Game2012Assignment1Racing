using UnityEngine;

public class Tires : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float playerSpeedBoostPerPickup = 0.35f;
    [SerializeField] private float roadSpeedBoostPerPickup = 0.35f;
    [SerializeField] private AudioClip collectClip;
    [SerializeField] [Range(0f, 1f)] private float collectVolume = 1f;

    private Score_Manager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<Score_Manager>();
    }

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

        if (collectClip != null)
        {
            AudioSource.PlayClipAtPoint(collectClip, transform.position, collectVolume);
        }

        player.AddSpeedBoost(playerSpeedBoostPerPickup);

        Road_Movements[] roads = FindObjectsOfType<Road_Movements>();
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i].AddSpeedBoost(roadSpeedBoostPerPickup);
        }

        if (scoreManager != null)
        {
            scoreManager.AddScore(5);
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
