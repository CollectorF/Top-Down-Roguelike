using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "Characters/Default")]
public class CharacterStarterInfo : ScriptableObject
{
    public float Speed;
    public float Bonus;
    public float Damage;
    public float MaxHealth;
}
