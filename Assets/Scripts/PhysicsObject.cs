using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour 
{
	public Material awakeMaterial = null;
	public Material sleepingMaterial = null;

	Rigidbody rb = null;

	bool wasSleeping = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		//Change colour based on whether the object is sleeping or not
		if (rb.IsSleeping() && !wasSleeping && sleepingMaterial != null)
		{
			wasSleeping = true;
			GetComponent<MeshRenderer>().material = sleepingMaterial;
		}
		if (!rb.IsSleeping() && wasSleeping && awakeMaterial != null)
		{
			wasSleeping = false;
			GetComponent<MeshRenderer>().material = awakeMaterial;
		}

	}

}
