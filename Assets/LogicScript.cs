using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LogicManagerScript : MonoBehaviour
{
    public int PlayerScore = 0;
    int HighScore;

    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public AudioSource scoreSound;
    public AudioSource DeathSound;
    private bool hasPlayedDeathSound = false;


    [ContextMenu("Increment Score")]
    public void addScore(int ScoreToAdd)
    {
        PlayerScore += ScoreToAdd;
        ScoreText.text = $"Score: {PlayerScore}";
        if (PlayerScore > HighScore)
        {
            HighScoreText.text = $"High Score: {PlayerScore}";
        }
        scoreSound.Play();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void gameOver()
    {
        if (PlayerScore > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);
            Debug.Log("New High Score: " + PlayerScore);
            HighScoreText.text = $"High Score: {PlayerScore}";
        }
        GameOverScreen.SetActive(true);
        if (!hasPlayedDeathSound)
        {
            DeathSound.Play();
            hasPlayedDeathSound = true;
        }

    }

    public void gameStart()
    {
        GameOverScreen.SetActive(false);
        PlayerScore = 0;
        ScoreText.text = $"Score: {PlayerScore}";
        HighScoreText.text = $"High Score: {HighScore}";
        hasPlayedDeathSound = false;
    }

    public void win()
    {
        if (PlayerScore > 20)
        {
            WinScreen.SetActive(true);
        }
    }
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = $"High Score: {HighScore}";
    }


}
