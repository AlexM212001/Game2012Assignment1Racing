using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 4.5f;
    [SerializeField] private bool useAccelerometer = true;

    private void Update()
    {
        float inputX = 0f;
        float inputY = 0f;

        // Touch: screen split into 4 directions from center
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

            inputX = touchPos.x < center.x ? -1f : 1f;
            inputY = touchPos.y < center.y ? -1f : 1f;
        }
        // Accelerometer fallback
        else if (useAccelerometer && Accelerometer.current != null)
        {
            Vector3 accel = Accelerometer.current.acceleration.ReadValue();
            inputX = Mathf.Clamp(accel.x, -1f, 1f);
            inputY = Mathf.Clamp(accel.y, -1f, 1f);
        }

        Vector3 pos = transform.position;
        pos.x += inputX * moveSpeed * Time.deltaTime;
        pos.y += inputY * moveSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traffic"))
        {
            // Handle collision with traffic
            Debug.Log("Collided with traffic!");
            //Destroy player game object
            Destroy(gameObject);
        }
    }
}