using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/PlayerStatsConfig", fileName = "PlayerStatsConfig", order = 54)]
public class PlayerStatsConfig : ScriptableObject
{
    [field: SerializeField] public float GroundSpeed { get; private set; } = 8;
    [field: SerializeField] public float AirSpeed { get; private set; } = 4;
    [field: SerializeField] public float JumpPower { get; private set; } = 12;
}
