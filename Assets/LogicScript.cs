using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LogicManagerScript : MonoBehaviour
{
    public int PlayerScore = 0;
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;
    public GameObject GameOverScreen;
    public AudioSource scoreSound;
    public AudioSource DeathSound;
    private bool hasPlayedDeathSound = false;


    [ContextMenu("Increment Score")]
    public void addScore(int ScoreToAdd)
    {
        PlayerScore += ScoreToAdd;
        ScoreText.text = $"Score: {PlayerScore}";
        scoreSound.Play();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        // set high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (PlayerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);
            Debug.Log("New High Score: " + PlayerScore);
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
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = $"High Score: {HighScore}";
        hasPlayedDeathSound = false;
    }


}
