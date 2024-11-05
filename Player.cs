using UnityEngine;

namespace spearthyself;

public partial class SpearThyself
{
	bool isHoldingSpear = false;

	private void PlayerOnUpdate(On.Player.orig_Update orig, Player slugcat, bool eu)
	{
		orig(slugcat, eu); //Always call original code, either before or after your code, depending on what you need to achieve


		if (Input.GetKeyDown(KeyCode.I))
			isHoldingSpear = CheckForSpear(slugcat);

		if (isHoldingSpear)
		{
			slugcat.Regurgitate();
		} else
		{
			slugcat.Jump();
		}
		/*if (Input.GetKeyDown(KeyCode.I))
		{
			if (slugcat.grasps[1] is Spear)
			{
				slugcat.Regurgitate();
			} else
			{
				slugcat.Jump();
			}
		}*/

		if (Input.GetKeyDown(KeyCode.K))
			slugcat.Regurgitate();
	}

	/*private bool CheckForSpear(Player slugcat)
	{
		foreach (var holding in slugcat.grasps)
		{
			if (holding is Spear)
				return true;
		}
		// if not already returned a value, return false
		return false;
	}*/
	private bool CheckForSpear(Player slugcat)
	{
		return false;
	}
}
