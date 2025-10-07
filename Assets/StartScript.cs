using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public string sceneToLoad = "Game";
    public AudioClip backgroundMusic;
    public TMP_Text highScoreText;
    public TMP_Dropdown difficultyDropdown;

    void Start()
    {
        if (backgroundMusic != null)
        {
            AudioSource.PlayClipAtPoint(backgroundMusic, Camera.main.transform.position);
        }

    }
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
        int selectedDifficulty = difficultyDropdown.value;
        PlayerPrefs.SetInt("Difficulty", selectedDifficulty);
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
