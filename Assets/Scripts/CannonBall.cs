using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour {
	public float forceOnFire = 300;
	
	bool fire = false;
	// bool canFire = true;

	Rigidbody rb = null;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
	}

	// void Update()
    // {
    //     FireCannonball();
    // }

    public void FireCannonball()
    {
		rb.isKinematic = false;
		rb.AddForce(transform.forward * forceOnFire);
		// canFire = false;
    }
}
