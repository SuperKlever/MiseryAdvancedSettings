using MelonLoader;

[assembly: MelonInfo(typeof(MiseryAdvancedSettings.Main), "Misery Advanced Settings", "0.9.0", "SuperKlever", null)]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace MiseryAdvancedSettings
{
	public class Main : MelonMod
    {
		public override void OnInitializeMelon()
        {
			Settings.OnLoad();
		}

		public override void OnUpdate()
		{
		}
	}
}