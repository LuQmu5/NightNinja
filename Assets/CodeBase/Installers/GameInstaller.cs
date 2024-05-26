using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    private const string PlayerStatsConfigPath = "StaticData/Character/CharacterConfig";

    public override void InstallBindings()
    {
        CharacterConfig playerStatsConfig = Resources.Load<CharacterConfig>(PlayerStatsConfigPath);

        Container.BindInstance(playerStatsConfig);
        Container.Bind<PlayerInput>().AsSingle();
    }
}