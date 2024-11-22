using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] Game _game;
    public override void InstallBindings()
    {
        Container.Bind<Game>().FromInstance(_game).AsSingle();
    }
}