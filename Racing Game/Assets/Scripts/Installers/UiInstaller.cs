using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
	[SerializeField] MainMenu _mainMenu;

	public override void InstallBindings()
    {
		Container.Bind<MainMenu>().FromInstance(_mainMenu).AsSingle();
	}
}