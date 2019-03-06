using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// [HideInInspector] 
	public float x;
	// [HideInInspector] 
	public float y;

	void Update()
	{
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
	}
}
