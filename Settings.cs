using ModSettings;

namespace MiseryAdvancedSettings
{
	internal class Settings : JsonModSettings
	{
		internal static Settings Instance { get; } = new Settings();

		internal static void OnLoad()
		{
			Settings.Instance.AddToModSettings("Misery Advanced Settings");
			Settings.Instance.RefreshGUI();
		}

		[Section("Main")]
		[Name("Unlock spawn choice in misery")]
		[ModSettings.Description("Be careful with the choice of location. Very low temperatures can kill you faster than you reach the shelter")]
		public bool spawnChoice = true;

		[Name("Unlock all items in misery")]
		[ModSettings.Description("Unlock clothes, tools, food, ammo and some other items that locked in Interloper and Misery modes")]
		public bool unlockItems = true;

		[Name("Unlock most weapons in misery")]
		[ModSettings.Description("Unlock revolver and rifle. Spawn revolver in 1 spot in each location that can contain it. Also unlocks some rifle spawns")]
		public bool unlockWeapons = true;
	}
}
