using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour {

	Animator animator = null;
	public List<Rigidbody> rigidbodies = new List<Rigidbody>();
	
	public bool RagdollOn 
	{
		get { return !animator.enabled; }
		set {
			animator.enabled = !value;
			foreach (Rigidbody r in rigidbodies)
				r.isKinematic = !value;
		}
	}

	void Start () {
		animator = GetComponent<Animator>();

		//auto grab rbs?
		rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

		//Set all connected rigidbodies on this object to kinematic 
		//so that the forces don't build up when converted back to dynamic rbs
		foreach (var r in rigidbodies)
		{
			r.isKinematic = true;
		}
	}
	
	void Update () {
		//Ragdoll trigger test
		// if (Input.GetKeyDown(KeyCode.Space))
		// {
		// 	RagdollOn = !RagdollOn;
		// }
	}
}
