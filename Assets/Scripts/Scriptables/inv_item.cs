using UnityEngine;
[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/Inv_Slot", order = 1)]
public class inv_item : ScriptableObject
{
	public int id;
	public int ammoLoaded;
	public int ammoSpare;
}
