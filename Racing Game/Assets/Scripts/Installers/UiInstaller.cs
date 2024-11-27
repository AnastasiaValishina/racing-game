using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
	[SerializeField] MainMenu _mainMenu;
	[SerializeField] Canvas _canvas;

	public override void InstallBindings()
    {
		Container.Bind<MainMenu>().FromInstance(_mainMenu).AsSingle();
		Container.Bind<Canvas>().FromInstance(_canvas).AsSingle();
	}
}