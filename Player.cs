using UnityEngine;

namespace spearthyself;

public partial class SpearThyself
{
	bool isHoldingSpear = false;

	private void PlayerOnUpdate(On.Player.orig_Update orig, Player slugcat, bool eu)
	{
		orig(slugcat, eu); //Always call original code, either before or after your code, depending on what you need to achieve

		if (Input.GetKeyDown(KeyCode.I))
		{
			isHoldingSpear = DestroySpear(slugcat);

			if (isHoldingSpear)
			{
				slugcat.Die();
				isHoldingSpear = false;
			} else // here for debugging purposes
			{
				slugcat.Jump();
			}
		}
	}

	private bool DestroySpear(Player slugcat)
	{
		if (slugcat.grasps == null)
			return false;


		foreach (var holding in slugcat.grasps)
		{
			// if slot is not empty and is holding a spear
			if (holding != null && holding.grabbed is Spear)
			{
				holding.grabbed.Destroy(); // GET THAT SHIT OUTTA HERE!!!!!!!!
				return true;
			}
		}
		// if not already returned a value, return false
		return false;
	}

	/*private void SpawnSpearInSlugcat(Player slugcat)
	{
		World world = slugcat.room.world;
		WorldCoordinate initalSpawnPos = new WorldCoordinate(slugcat.room.index, slugcat.bodyChunks[0].pos);

		AbstractPhysicalObject abtractObject = new AbstractPhysicalObject(slugcat.room.world, AbstractPhysicalObject.AbstractObjectType.Spear, null, )
	}*/
}
