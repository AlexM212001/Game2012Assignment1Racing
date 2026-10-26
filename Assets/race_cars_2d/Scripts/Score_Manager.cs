using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text lastScoreText;
    public int HighScore;

    public static int LastScore;



    private void Start()
    {
        UpdateScoreText();
       
        StartCoroutine(ScoreCoroutine());
        StartCoroutine(Reload());
        HighScore = PlayerPrefs.GetInt("HighScore", 0);

      highScoreText.text = "High Score: " + HighScore.ToString();
        lastScoreText.text = "Last Score: " + LastScore.ToString();
    }

    public void AddScore(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            Debug.Log("New High Score: " + HighScore);
        }
    }

    private IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            AddScore(1);
            LastScore = score;

        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Game");
    }
}
