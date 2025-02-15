using Il2Cpp;
using Il2CppTLD.Gameplay;
using Il2CppTLD.Scenes;

namespace MiseryAdvancedSettings
{
	internal class Patch
	{
		[HarmonyLib.HarmonyPatch(typeof(Panel_SelectExperience), nameof(Panel_SelectExperience.Initialize))]
		internal class Panel_SelectExperienceInitializePatch
		{ 
		
		}

		[HarmonyLib.HarmonyPatch(typeof(Panel_SelectExperience), nameof(Panel_SelectExperience.OnExperienceClicked))]
		internal class OnExperienceClickedPatch
		{
			internal static void Prefix(ref Panel_SelectExperience __instance)
			{
				//MelonLogger.Msg("OnExperienceClicked log");
				if (Settings.Instance.spawnChoice == true)
					if (__instance.m_LastItemIndexSelected == 4 || __instance.m_LastItemIndexSelected == 3) 
					{
						Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<RegionSpecification> allRegionList = __instance.m_MenuItems[0].m_SandboxConfig.m_AvailableStartRegions;
						SandboxConfig instance = __instance.m_PreviousMenuItemSelected.m_SandboxConfig;
						instance.m_StartRegionSelectionBlocked = false;
						instance.m_AvailableStartRegions = allRegionList;
						instance.m_ForceSceneLoad = null;
					}
			}
		}

		[HarmonyLib.HarmonyPatch(typeof(DisableObjectForXPMode), nameof(DisableObjectForXPMode.ShouldDisableForCurrentMode))]
		internal class DisableObjectForXPModePatch
		{
			private static void Postfix(ref DisableObjectForXPMode __instance, ref bool __result)
			{
				if (Settings.Instance.unlockItems == true)
					if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Misery)
					{
						if (__result == true)
						{
							__result = false;
						}
					}
			}
		}

		[HarmonyLib.HarmonyPatch(typeof(DisableObjectForGameMode), nameof(DisableObjectForGameMode.ShouldDisableForCurrentMode))]
		internal class DisableObjectForGameModePatch
		{
			private static void Postfix(ref DisableObjectForGameMode __instance, ref bool __result)
			{
				if (Settings.Instance.unlockItems == true)
					if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Misery)
					{
						if (__result == true)
						{
							__result = false;
						}
					}
			}
		}

		[HarmonyLib.HarmonyPatch(typeof(RandomSpawnObject), nameof(RandomSpawnObject.Start))]
		internal class RandomSpawnObjectPatch
		{
			private static void Postfix(ref RandomSpawnObject __instance)
			{
				if (Settings.Instance.unlockWeapons == true)
				{
					if (__instance.m_NumObjectsToEnableInterloper == 0)
						__instance.m_NumObjectsToEnableInterloper = 1;
					if (__instance.m_NumObjectsToEnableByLevel[0] == 0)
						__instance.m_NumObjectsToEnableByLevel[0] = 1;
					//MelonLogger.Msg($"SMF with fun {__instance.GetNumObjectsToEnableCurrentXPMode()} and var {__instance.m_NumObjectsToEnableInterloper} and arr {__instance.m_NumObjectsToEnableByLevel[0]}");
				}
			}
		}
	}
}
