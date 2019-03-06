using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerControl : MonoBehaviour {
	
	[SerializeField] float speed = 80f;
	[SerializeField] float pushPower = 2f;
	CharacterController controller;
	Animator animator;
	PlayerInput input;


	void Awake()
	{
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		input = GetComponent<PlayerInput>();
	}

	void Update()
	{
		ControlPlayer();
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;

		//Kinematic rbs don't get affected
		if (body == null || body.isKinematic)
			return;

		if (hit.moveDirection.y < -0.3F)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}

	#region UtilityFunctions
	void ControlPlayer()
	{
		//Move and rotate player
		// controller.SimpleMove(transform.forward * input.y * speed * Time.deltaTime);
		controller.SimpleMove(transform.up * Time.deltaTime);
		transform.Rotate(transform.up, input.x * speed * Time.deltaTime);

		//Animators
		animator.SetFloat("Speed", input.y * speed * Time.deltaTime);
	}
	#endregion
}
