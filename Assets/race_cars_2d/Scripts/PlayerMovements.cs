using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 6f;
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 4.5f;
    [SerializeField] private bool useAccelerometer = true;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float maxTiltAngle = 20f;
    private float baseFacingAngle = 180f;

    public GameObject gameOverPanel;

  void Start()
    {
       
            gameOverPanel.SetActive(false);
        
    }

    private float stackedSpeedBonus = 0f;

    private void Update()
    {
        float inputX = 0f;
        float inputY = 0f;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

            inputX = touchPos.x < center.x ? -1f : 1f;
            inputY = touchPos.y < center.y ? -1f : 1f;
        }
        else if (useAccelerometer && Accelerometer.current != null)
        {
            Vector3 accel = Accelerometer.current.acceleration.ReadValue();
            inputX = Mathf.Clamp(accel.x, -1f, 1f);
            inputY = Mathf.Clamp(accel.y, -1f, 1f);
        }

        float currentMoveSpeed = baseMoveSpeed + stackedSpeedBonus;

        Vector3 pos = transform.position;
        pos.x += inputX * currentMoveSpeed * Time.deltaTime;
        pos.y += inputY * currentMoveSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        float targetZ = baseFacingAngle - (inputX * maxTiltAngle);
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void AddSpeedBoost(float amount)
    {
        if (amount <= 0f)
        {
            return;
        }

        stackedSpeedBonus += amount;
    }

    // player collides with traffic, destroy the player and show game over panel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traffic"))
        {
            Debug.Log("Collided with traffic!");
            Destroy(gameObject);
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}