using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Button button;
    public Image characterIcon;
    public TMP_Text buttonText; // "Buy", "Select", "Selected"

    private CharacterData data;
    private ShopManager manager;
    private ShopUI shopUI;

    public void Setup(CharacterData d, ShopManager m, ShopUI ui)
    {
        data = d;
        manager = m;
        shopUI = ui;

        nameText.text = data.characterName;
        characterIcon.color = data.color;
        
        UpdateButtonState();
        
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    public void UpdateButtonState()
    {
        bool isUnlocked = manager.IsCharacterUnlocked(data.id);
        bool isSelected = manager.SelectedCharacterID == data.id;

        if (isSelected)
        {
            buttonText.text = "Selected";
            button.interactable = false;
            priceText.text = "Owned";
        }
        else if (isUnlocked)
        {
            buttonText.text = "Select";
            button.interactable = true;
            priceText.text = "Owned";
        }
        else
        {
            buttonText.text = "Buy";
            priceText.text = data.price.ToString();
            button.interactable = manager.TotalCoins >= data.price;
        }
    }

    void OnClick()
    {
        if (manager.IsCharacterUnlocked(data.id))
        {
            manager.SelectedCharacterID = data.id;
        }
        else
        {
            if (manager.TryBuyCharacter(data))
            {
                // Success
            }
        }
        shopUI.UpdateAllItems();
    }
}
