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

    public AudioSource WinSound;
    public bool hasWon = false;


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
        if (WinScreen.activeSelf) return;
        if (PlayerScore > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);
            HighScoreText.text = $"High Score: {PlayerScore}";
        }
        GameOverScreen.SetActive(true);
    }

    public void gameStart()
    {
        GameOverScreen.SetActive(false);
        PlayerScore = 0;
        ScoreText.text = $"Score: {PlayerScore}";
        HighScoreText.text = $"High Score: {HighScore}";
        GameObject bean = GameObject.FindGameObjectWithTag("Player");
        if (bean)
        {
            BEANScript beanScript = bean.GetComponent<BEANScript>();
            if (beanScript)
            {
                beanScript.isAlive = true;
                beanScript.hasPlayedDeathSound = false;
            }
        }
    }

    public void win()
    {
        WinSound.Play();
        WinScreen.SetActive(true);
        if (PlayerScore > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);
            HighScoreText.text = $"High Score: {PlayerScore}";
        }

        GameObject bean = GameObject.FindGameObjectWithTag("Player");
        if (bean)
        {
            BEANScript beanScript = bean.GetComponent<BEANScript>();
            if (beanScript)
            {
                beanScript.isAlive = false;
            }
        }
        hasWon = true;
    }
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = $"High Score: {HighScore}";
    }


}
