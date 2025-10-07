using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public string sceneToLoad = "Game";
    public TMP_Text highScoreText;
    public TMP_Dropdown difficultyDropdown;

    void Update()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    public void StartGame()
    {
        // Add null check for dropdown
        if (difficultyDropdown != null)
        {
            int selectedDifficulty = difficultyDropdown.value;
            PlayerPrefs.SetInt("Difficulty", selectedDifficulty);
        }

        // Add debug logging to see if method is being called
        Debug.Log("StartGame method called, loading scene: " + sceneToLoad);

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
