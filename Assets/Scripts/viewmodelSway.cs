using UnityEngine;

public class viewmodelSway : MonoBehaviour
{
	public float sensitivity;
	public float lerp;

	void LateUpdate()
	{

		//Get input
		Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity, Input.GetAxisRaw("Mouse Y") * sensitivity);
		//Calculate
		Quaternion target = (Quaternion.AngleAxis(-mouseInput.y, transform.right)) * (Quaternion.AngleAxis(mouseInput.x, transform.up));
		//Apply
		transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * lerp);
	}
}
