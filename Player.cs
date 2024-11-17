using UnityEngine;

namespace spearthyself;

public partial class SpearThyself
{
	Spear slugcatSpear;

	private void PlayerOnUpdate(On.Player.orig_Update orig, Player slugcat, bool eu)
	{
		orig(slugcat, eu); //Always call original code, either before or after your code, depending on what you need to achieve

		slugcatSpear = GetSpearFromSlugcat(slugcat);

		if (suicideButton.CheckRawPressed(slugcat.playerState.playerNumber))
		{
			if (slugcatSpear != null)
			{
				SharedPhysics.CollisionResult result = new SharedPhysics.CollisionResult();
				result.obj = slugcat;

				// stabs yourself lol!!!!!!!!!!!!!!
				slugcatSpear.HitSomething(result, eu);
				if (slugcatSpear is ExplosiveSpear explosiveSpear)
					explosiveSpear.Ignite();
				slugcat.Die();
				slugcatSpear = null;
			}
		}
	}

	private Spear GetSpearFromSlugcat(Player slugcat)
	{
		if (slugcat.grasps == null)
			return null;


		foreach (var holding in slugcat.grasps)
		{
			// if slot is not empty and is holding a spear
			if (holding != null && holding.grabbed is ExplosiveSpear)
			{
				return (ExplosiveSpear)holding.grabbed;
			}
			else if (holding != null && holding.grabbed is Spear)
			{
				return (Spear)holding.grabbed;
			}
		}
		// if no spear is found, return null
		return null;
	}
}
