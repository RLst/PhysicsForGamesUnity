using UnityEngine;

public class PickableObject : MonoBehaviour {

	//Object needs ref selected and unselected materials and camera
	[SerializeField] Material selectedMat;
	[SerializeField] Material unselectedMat;

	Camera cam;

	void Start()
	{
		cam = Camera.main;	//Use of tags! Be careful
	}

	// void Update()
	// {
	// 	if (Input.GetMouseButtonDown()
	// }

}
