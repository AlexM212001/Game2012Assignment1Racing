using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text ScoreText;

    public int HighScore;
    public int Score;

    public Score_Manager score_Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       HighScore = PlayerPrefs.GetInt("HighScore", 0);
        Score = score_Manager.score;
        highScoreText.text = "High Score: " + HighScore.ToString();
        ScoreText.text = "Score: " + Score.ToString();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
