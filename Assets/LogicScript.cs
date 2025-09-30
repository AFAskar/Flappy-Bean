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
        GameOverScreen.SetActive(true);
    }


}
