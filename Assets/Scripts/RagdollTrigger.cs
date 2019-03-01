using UnityEngine;

public class RagdollTrigger : MonoBehaviour {

	new Collider collider;
	new Rigidbody rigidbody;

	void Awake()
	{
		collider = GetComponent<Collider>();
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.anyKeyDown)
		{
			//Let go of wrecking ball!
			rigidbody.isKinematic = !rigidbody.isKinematic;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		Ragdoll ragdoll = col.gameObject.GetComponentInParent<Ragdoll>();
		if (ragdoll != null)
		{
			//Trigger ragdoll and turn it back into a normal collider
			ragdoll.RagdollOn = true;
			collider.isTrigger = false;
			rigidbody.mass = 100f;
			rigidbody.AddForce(Vector3.back * 100000f);
		}
			
	}
}
