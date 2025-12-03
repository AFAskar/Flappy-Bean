using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    public ShopManager shopManager;
    public GameObject shopPanel;
    
    [Header("UI Elements")]
    public Image characterIconImage;
    public TMP_Text priceText;
    public Button actionButton;
    public TMP_Text actionButtonText;
    public TMP_Text coinText;
    
    [Header("Navigation")]
    public Button prevButton;
    public Button nextButton;

    private int currentIndex = 0;

    void Start()
    {
        if (shopManager == null) shopManager = ShopManager.Instance;
        
        // Setup Navigation Buttons
        if (prevButton) prevButton.onClick.AddListener(PrevCharacter);
        if (nextButton) nextButton.onClick.AddListener(NextCharacter);
        if (actionButton) actionButton.onClick.AddListener(OnActionClick);

        RefreshShop();
    }

    void OnEnable()
    {
        UpdateCoinText();
        RefreshShop();
    }

    public void RefreshShop()
    {
        if (shopManager == null || shopManager.characterList.Length == 0) return;

        // Clamp index
        if (currentIndex < 0) currentIndex = 0;
        if (currentIndex >= shopManager.characterList.Length) currentIndex = shopManager.characterList.Length - 1;

        CharacterData data = shopManager.characterList[currentIndex];
        UpdateDisplay(data);
    }

    void UpdateDisplay(CharacterData data)
    {
        // Icon (Use override sprite if available, else color)
        if (characterIconImage)
        {
            if (data.overrideSprite != null)
            {
                characterIconImage.sprite = data.overrideSprite;
                characterIconImage.color = Color.white;
            }
            else
            {
                if (shopManager.defaultCharacterSprite != null)
                {
                    characterIconImage.sprite = shopManager.defaultCharacterSprite;
                }
                characterIconImage.color = data.color;
            }
        }

        // Button State
        bool isUnlocked = shopManager.IsCharacterUnlocked(data.id);
        bool isSelected = shopManager.SelectedCharacterID == data.id;

        if (isSelected)
        {
            actionButtonText.text = "Selected";
            actionButton.interactable = false;
            if (priceText) priceText.text = "Owned";
        }
        else if (isUnlocked)
        {
            actionButtonText.text = "Select";
            actionButton.interactable = true;
            if (priceText) priceText.text = "Owned";
        }
        else
        {
            actionButtonText.text = "Buy";
            if (priceText) priceText.text = data.price.ToString();
            actionButton.interactable = shopManager.TotalCoins >= data.price;
        }
        
        UpdateCoinText();
    }

    public void NextCharacter()
    {
        if (shopManager == null) return;
        currentIndex = (currentIndex + 1) % shopManager.characterList.Length;
        RefreshShop();
    }

    public void PrevCharacter()
    {
        if (shopManager == null) return;
        currentIndex--;
        if (currentIndex < 0) currentIndex = shopManager.characterList.Length - 1;
        RefreshShop();
    }

    public void OnActionClick()
    {
        CharacterData data = shopManager.characterList[currentIndex];
        
        if (shopManager.IsCharacterUnlocked(data.id))
        {
            shopManager.SelectedCharacterID = data.id;
        }
        else
        {
            if (shopManager.TryBuyCharacter(data))
            {
                // Success sound?
            }
        }
        RefreshShop();
    }

    public void UpdateCoinText()
    {
        if (coinText != null && shopManager != null)
        {
            coinText.text = "Coins: " + shopManager.TotalCoins;
        }
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        RefreshShop();
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
}
