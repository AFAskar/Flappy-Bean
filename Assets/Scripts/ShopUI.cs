using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    public ShopManager shopManager;
    public Transform container;
    public GameObject itemPrefab;
    public GameObject shopPanel;
    public TMP_Text coinText;

    private List<ShopItemUI> items = new List<ShopItemUI>();

    void Start()
    {
        // If shopManager is not assigned, try to find it
        if (shopManager == null) shopManager = ShopManager.Instance;
        
        // Populate shop
        RefreshShop();
    }

    void OnEnable()
    {
        UpdateCoinText();
        UpdateAllItems();
    }

    public void RefreshShop()
    {
        // Clear existing
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        items.Clear();

        if (shopManager == null) return;

        foreach (var charData in shopManager.characterList)
        {
            GameObject obj = Instantiate(itemPrefab, container);
            ShopItemUI itemUI = obj.GetComponent<ShopItemUI>();
            itemUI.Setup(charData, shopManager, this);
            items.Add(itemUI);
        }
    }

    public void UpdateAllItems()
    {
        foreach (var item in items)
        {
            item.UpdateButtonState();
        }
        UpdateCoinText();
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
        UpdateAllItems();
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
}
