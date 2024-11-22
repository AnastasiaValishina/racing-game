using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] Game _game;
    [SerializeField] TrackCheckPoints _trackCheckPoints;
    [SerializeField] Timer _timer;
    [SerializeField] MainMenu _mainMenu;

    public override void InstallBindings()
    {
        Container.Bind<Game>().FromInstance(_game).AsSingle();
        Container.Bind<TrackCheckPoints>().FromInstance(_trackCheckPoints).AsSingle();
        Container.Bind<Timer>().FromInstance(_timer).AsSingle();
        Container.Bind<MainMenu>().FromInstance(_mainMenu).AsSingle();
    }
}