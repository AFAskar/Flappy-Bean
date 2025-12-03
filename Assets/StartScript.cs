using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    public string sceneToLoad = "Game";
    public TMP_Text highScoreText;
    public TMP_Dropdown difficultyDropdown;
    public Image beanImage;
    public ShopUI shopUI;
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
    void Awake()
    {
        previousDifficulty = PlayerPrefs.GetInt("Difficulty", 0);
        if (difficultyDropdown != null)
        {
            difficultyDropdown.value = previousDifficulty;
        }
    }

    void Start()
    {
        UpdateBeanImage();
    }

    public void UpdateBeanImage()
    {
        if (beanImage == null) return;

        if (ShopManager.Instance != null)
        {
            CharacterData selectedChar = ShopManager.Instance.GetSelectedCharacter();
            if (selectedChar != null)
            {
                if (selectedChar.overrideSprite != null)
                {
                    beanImage.sprite = selectedChar.overrideSprite;
                    beanImage.color = Color.white;
                }
                else
                {
                    // Assuming the default sprite is already set or we don't want to change it if no override
                    // But we should probably set color if it's a tint-based character
                    beanImage.color = selectedChar.color;
                }
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void OpenShop()
    {
        if (shopUI != null) shopUI.OpenShop();
    }
    public void CloseShop()
    {
        if (shopUI != null) shopUI.CloseShop();
        UpdateBeanImage();
    }
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
