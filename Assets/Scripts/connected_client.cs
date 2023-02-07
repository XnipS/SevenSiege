using UnityEngine;
using Mirror;

public class connected_client : NetworkBehaviour
{
	[HideInInspector]
	public GameObject myPlayer = null;

	void Start()
	{
		if (hasAuthority)
		{
			Respawn(false, respawn_manager.singleton.transform.GetChild(Random.Range(0, transform.childCount)).position);
		}
	}


	[ClientRpc]
	public void RPC_PlayerDeath(Vector3 deathPos)
	{
		if (hasAuthority)
		{
			//TODO
			//FindObjectOfType<respawn_manager>().CMD_SpawnBag(deathPos, FindObjectOfType<ui_inventory>().invent.ToArray());
			//FindObjectOfType<ui_inventory>().SetDefaultItems();
		}
	}



	public void Respawn(bool rnd, Vector3 pos)
	{
		if (hasAuthority)
		{
			if (myPlayer == null)
			{
				//Respawn
				//Debug.Log(rnd + " - " + pos + " - " + GetComponent<NetworkIdentity>().connectionToClient);
				respawn_manager.singleton.CMD_SpawnPlayer(pos, rnd, GetComponent<NetworkIdentity>().connectionToClient);
			}
		}
	}
}
