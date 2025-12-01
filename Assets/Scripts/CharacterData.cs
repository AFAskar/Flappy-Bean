using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Shop/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Color color = Color.white;
    public int price;
    public string id; // Unique ID for saving
    public Sprite icon; // Optional: if we want a specific icon in the shop
    public Sprite overrideSprite; // Optional: Overrides the default sprite (useful for Light/Dark variants)
}
