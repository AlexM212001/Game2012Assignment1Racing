using UnityEngine;

public class Road_Movements : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float resetY = -20f;
    [SerializeField] private float recycleHeight = 40f;

    private void Update()
    {
        var position = transform.position;
        position.y -= moveSpeed * Time.deltaTime;

        // Keep movement smooth by preserving overshoot at reset.
        while (position.y <= resetY)
        {
            position.y += recycleHeight;
        }

        transform.position = position;
    }
}
