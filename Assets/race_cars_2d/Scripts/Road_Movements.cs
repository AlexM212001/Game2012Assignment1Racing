using UnityEngine;

public class Road_Movements : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 6f;
    [SerializeField] private float resetY = -20f;
    [SerializeField] private float recycleHeight = 40f;

    private float stackedSpeedBonus = 0f;

    private void Update()
    {
        float currentMoveSpeed = baseMoveSpeed + stackedSpeedBonus;

        Vector3 position = transform.position;
        position.y -= currentMoveSpeed * Time.deltaTime;

        while (position.y <= resetY)
        {
            position.y += recycleHeight;
        }

        transform.position = position;
    }

    public void AddSpeedBoost(float amount)
    {
        if (amount <= 0f)
        {
            return;
        }

        stackedSpeedBonus += amount;
    }
}
