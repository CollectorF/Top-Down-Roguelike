using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "Characters/Default")]
public class CharacterStarterInfo : ScriptableObject
{
    public float Speed;
    public int Bonus;
    public int Damage;
    public int MaxHealth;
}
