using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class playerInventory : NetworkBehaviour
{
	public GameObject prefab_droppedItem;
	public AnimationClip anim_pickup;
	public AnimationClip anim_drop;

	void Start()
	{
		if (!hasAuthority) { return; }

	}

	[Command(requiresAuthority = false)]
	public void CMD_SpawnDroppedItem(inv_item data, Vector3 pos)
	{
		GameObject ga = Instantiate(prefab_droppedItem, pos, Quaternion.identity);
		NetworkServer.Spawn(ga);
		ga.GetComponent<droppedItem>().RPC_SyncItemData(data);
	}

	[ClientRpc]
	public void RPC_GiveItem(inv_item data, bool fromGround)
	{
		if (hasAuthority)
		{
			//TODO myInv.GiveItem(data);
			if (fromGround)
			{
				GetComponent<playerWeapons>().CMD_PlayWeaponAnimation(anim_pickup.name, GetComponent<playerWeapons>().currentWeapon, false, false);
			}
		}
	}
	public void DropItemAnimation()
	{
		GetComponent<playerWeapons>().CMD_PlayWeaponAnimation(anim_drop.name, GetComponent<playerWeapons>().currentWeapon, false, false);
	}
}
