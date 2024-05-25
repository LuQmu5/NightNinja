using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    private const string PlayerStatsConfigPath = "StaticData/Player/PlayerStatsConfig";

    public override void InstallBindings()
    {
        PlayerStatsConfig playerStatsConfig = Resources.Load<PlayerStatsConfig>(PlayerStatsConfigPath);

        Container.BindInstance(playerStatsConfig);
        Container.Bind<PlayerInput>().AsSingle();
    }
}