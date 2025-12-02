using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LogicManagerScript : MonoBehaviour
{
    public int PlayerScore = 0;
    public int CoinsCollected = 0;
    public float timeLimit = 60f;
    private float timer = 0f;
    public bool isGameActive = false;

    public TMP_Text ScoreText;
    [UnityEngine.Serialization.FormerlySerializedAs("HighScoreText")]
    public TMP_Text CoinText;
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
        scoreSound.Play();
    }

    public void addCoin(int coinsToAdd)
    {
        CoinsCollected += coinsToAdd;
        CoinText.text = $"Coins: {CoinsCollected}";
        
        // Update total coins in PlayerPrefs immediately or at end of game? 
        // Original code updated TotalCoins in addScore. Let's keep it consistent.
        int currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        PlayerPrefs.SetInt("TotalCoins", currentCoins + coinsToAdd);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void gameOver()
    {
        if (WinScreen.activeSelf) return;
        isGameActive = false;
        GameOverScreen.SetActive(true);
    }

    public void gameStart()
    {
        GameOverScreen.SetActive(false);
        PlayerScore = 0;
        CoinsCollected = 0;
        timer = timeLimit;
        isGameActive = true;

        ScoreText.text = $"Score: {PlayerScore}";
        CoinText.text = $"Coins: {CoinsCollected}";
        
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

    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                win();
            }
        }
    }

    public void win()
    {
        isGameActive = false;
        WinSound.Play();
        WinScreen.SetActive(true);
        
        // Update high score if needed, though we are focusing on coins now.
        // Keeping high score logic in background if we want to persist it, 
        // but UI now shows coins.
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (PlayerScore > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);
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
        gameStart();
    }


}
