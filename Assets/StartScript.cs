using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public string sceneToLoad = "Game";
    public TMP_Text highScoreText;
    public TMP_Dropdown difficultyDropdown;
    private int previousDifficulty = 0;
    void Update()
    {

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        if (difficultyDropdown != null)
        {
            int selectedDifficulty = difficultyDropdown.value;
            PlayerPrefs.SetInt("Difficulty", selectedDifficulty);
        }
    }
    public void StartGame()
    {
        previousDifficulty = PlayerPrefs.GetInt("Difficulty", 0);

        if (difficultyDropdown != null)
        {
            if (difficultyDropdown.value != previousDifficulty)
            {
                difficultyDropdown.value = previousDifficulty;
            }
        }
        SceneManager.LoadScene(sceneToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
