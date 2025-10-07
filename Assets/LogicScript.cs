using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LogicManagerScript : MonoBehaviour
{
    public int PlayerScore = 0;
    public TMP_Text ScoreText;
    public GameObject GameOverScreen;


    [ContextMenu("Increment Score")]
    public void addScore(int ScoreToAdd)
    {
        PlayerScore += ScoreToAdd;
        ScoreText.text = $"Score: {PlayerScore}";
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
        }
        GameOverScreen.SetActive(true);
    }

    public void gameStart()
    {
        GameOverScreen.SetActive(false);
        PlayerScore = 0;
        ScoreText.text = $"Score: {PlayerScore}";
    }


}
