using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class respawn_manager : NetworkBehaviour
{
	public static respawn_manager singleton { get; private set; }
	public GameObject playerPrefab;
	public GameObject deadPlayerBag;

	// Singleton
	private void Awake()
	{
		if (singleton != null && singleton != this)
		{
			Destroy(this);
		}
		else
		{
			singleton = this;
		}
	}

	[Command(requiresAuthority = false)]
	public void CMD_SpawnPlayer(Vector3 pos, bool random, NetworkConnectionToClient request)
	{
		if (random)
		{
			Transform spawnPoint = transform.GetChild(Random.Range(0, transform.childCount));
			GameObject ga = Instantiate(playerPrefab, spawnPoint.position + Vector3.up, spawnPoint.rotation);
			NetworkServer.Spawn(ga, request);
			ga.GetComponent<NetworkIdentity>().AssignClientAuthority(request);
		}
		else
		{
			GameObject ga = Instantiate(playerPrefab, pos + Vector3.up, Quaternion.identity);
			NetworkServer.Spawn(ga, request);
			ga.GetComponent<NetworkIdentity>().AssignClientAuthority(request);
		}
	}

	[Command(requiresAuthority = false)]
	public void CMD_SpawnBag(Vector3 pos, inv_item[] inventory)
	{
		//TO DO
		// List<inv_item> sorted = new List<inv_item>();
		// for (int i = 0; i < inventory.Length; i++)
		// {
		// 	inventory[i].slot = i;
		// 	sorted.Add(inventory[i]);
		// }

	}
}
