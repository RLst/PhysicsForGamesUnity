using UnityEngine;

public class RagdollTrigger : MonoBehaviour {

	Collider col;
	Rigidbody rb;

	void Awake()
	{
		col = GetComponent<Collider>();
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{

	}

	void OnTriggerEnter(Collider col)
	{
		Ragdoll ragdoll = col.gameObject.GetComponentInParent<Ragdoll>();
		if (ragdoll != null)
		{
			//Trigger ragdoll and turn it back into a normal collider
			ragdoll.RagdollOn = true;
			this.col.isTrigger = false;
			rb.mass = 100f;
			rb.AddForce(Vector3.back * 100000f);
		}
			
	}

	public void Trigger()
	{
		//Let go of wrecking ball!
		rb.isKinematic = !rb.isKinematic;
	}
}
