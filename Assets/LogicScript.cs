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
    public TMP_Text WinScoreText;
    public TMP_Text WinCoinText;
    public GameObject[] WinStars; // Assign 3 star objects in Inspector
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
        
        // Update Win Screen UI
        if (WinScoreText != null) WinScoreText.text = $"Score: {PlayerScore}";
        if (WinCoinText != null) WinCoinText.text = $"+{CoinsCollected}";

        // Star Logic
        if (WinStars != null && WinStars.Length == 3)
        {
            // Reset stars (optional, depending on how they are set up)
            foreach (var star in WinStars) star.SetActive(false);

            // 1 Star: Always
            WinStars[0].SetActive(true);

            // 2 Stars: Score > 5 (Example threshold)
            if (PlayerScore > 5) WinStars[1].SetActive(true);

            // 3 Stars: Score > 10 (Example threshold)
            if (PlayerScore > 10) WinStars[2].SetActive(true);
        }
        
        // Update high score if needed
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
