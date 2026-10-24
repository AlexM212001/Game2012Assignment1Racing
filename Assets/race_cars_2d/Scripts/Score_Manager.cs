using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Score_Manager : MonoBehaviour
{

    public int score = 0;
    [SerializeField] private TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScoreCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString(); // Update the score text with the current score
    }

    IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f); // Wait for 0.8 seconds
            score++; // Increment the score by 1
            Debug.Log("Score: " + score); // Print the score to the console
        }
    }
}
