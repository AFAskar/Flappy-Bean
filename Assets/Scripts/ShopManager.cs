using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public CharacterData[] characterList;
    
    private const string PREF_SELECTED_CHARACTER = "SelectedCharacterID";
    private const string PREF_UNLOCKED_PREFIX = "CharacterUnlocked_";
    private const string PREF_TOTAL_COINS = "TotalCoins";

    public static ShopManager Instance;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public int TotalCoins
    {
        get => PlayerPrefs.GetInt(PREF_TOTAL_COINS, 0);
        set 
        {
            PlayerPrefs.SetInt(PREF_TOTAL_COINS, value);
            PlayerPrefs.Save();
        }
    }

    public string SelectedCharacterID
    {
        get 
        {
            if (characterList == null || characterList.Length == 0) return "";
            return PlayerPrefs.GetString(PREF_SELECTED_CHARACTER, characterList[0].id);
        }
        set
        {
            PlayerPrefs.SetString(PREF_SELECTED_CHARACTER, value);
            PlayerPrefs.Save();
        }
    }

    public bool IsCharacterUnlocked(string id)
    {
        // Default character (first one) is always unlocked
        if (characterList.Length > 0 && characterList[0].id == id) return true;
        return PlayerPrefs.GetInt(PREF_UNLOCKED_PREFIX + id, 0) == 1;
    }

    public void UnlockCharacter(string id)
    {
        PlayerPrefs.SetInt(PREF_UNLOCKED_PREFIX + id, 1);
        PlayerPrefs.Save();
    }

    public bool TryBuyCharacter(CharacterData character)
    {
        if (IsCharacterUnlocked(character.id)) return true; // Already owned

        if (TotalCoins >= character.price)
        {
            TotalCoins -= character.price;
            UnlockCharacter(character.id);
            return true;
        }
        return false;
    }

    public CharacterData GetSelectedCharacter()
    {
        string id = SelectedCharacterID;
        foreach (var c in characterList)
        {
            if (c.id == id) return c;
        }
        // Fallback to first character
        if (characterList.Length > 0) return characterList[0];
        return null;
    }
    
    // Helper to get color for GameScene
    public static Color GetSelectedCharacterColor()
    {
        // This assumes ShopManager might not be present in GameScene, 
        // so we might need to read PlayerPrefs directly or rely on a persistent ShopManager.
        // For now, let's read PlayerPrefs directly if Instance is null, 
        // but we need the CharacterData assets to map ID to Color.
        // If ShopManager is not in GameScene, we can't easily map ID to Color without loading assets.
        // Alternative: Save the color components to PlayerPrefs when selecting? 
        // Or just ensure ShopManager is DontDestroyOnLoad?
        // Let's make ShopManager DontDestroyOnLoad for now to be safe, or just find it if it exists.
        
        if (Instance != null)
        {
            var c = Instance.GetSelectedCharacter();
            return c != null ? c.color : Color.white;
        }
        
        // Fallback if no ShopManager (shouldn't happen if we set it up right, or we can use Resources.Load)
        return Color.white;
    }
}
