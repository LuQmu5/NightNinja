using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/PlayerStatsConfig", fileName = "PlayerStatsConfig", order = 54)]
public class PlayerStatsConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
}
