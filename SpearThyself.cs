using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using RWCustom;
using BepInEx;
using Debug = UnityEngine.Debug;
using System.Data.SqlClient;

using ImprovedInput;

// bypass fields that are set to private
#pragma warning disable CS0618
[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace spearthyself;

[BepInPlugin("mechinsam.spearthyself", "Spear Thyself", "1.0.0")]


public partial class SpearThyself : BaseUnityPlugin
{
	public static readonly PlayerKeybind suicideButton = PlayerKeybind.Register("spearthyself:suicide", "Spear Thyself", "Suicide", KeyCode.I, KeyCode.Joystick1Button4);

	private void OnEnable()
	{
		On.RainWorld.OnModsInit += RainWorldOnOnModsInit;
	}

	private bool IsInit;
	private void RainWorldOnOnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
	{
		orig(self);
		try
		{
			if (IsInit) return;

			// hooks
			On.Player.Update += PlayerOnUpdate;

			On.RainWorldGame.ShutDownProcess += RainWorldGameOnShutDownProcess;
			On.GameSession.ctor += GameSessionOnctor;
			
			IsInit = true;
		}
		catch (Exception ex)
		{
			Logger.LogError(ex);
			throw;
		}
	}
	
	// free variables and methods from memory when shutting down rain world
	private void RainWorldGameOnShutDownProcess(On.RainWorldGame.orig_ShutDownProcess orig, RainWorldGame self)
	{
		orig(self);
		ClearMemory();
	}
	private void GameSessionOnctor(On.GameSession.orig_ctor orig, GameSession self, RainWorldGame game)
	{
		orig(self, game);
		ClearMemory();
	}

	#region Helper Methods

	private void ClearMemory()
	{
		//If you have any collections (lists, dictionaries, etc.)
		//Clear them here to prevent a memory leak
		//YourList.Clear();
	}

	#endregion
}
