using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FloatShip))]
public class BoatControllerScript : MonoBehaviour
{
	/*public Vector3 COM;
	[Space(15)]*/
	public float walkSpeed = 2;
	public float runSpeed = 6;

	public float turnSmoothTime = 1f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;

	Transform cameraT;

	void Start()
	{
		//animator = GetComponent<Animator>();
		cameraT = Camera.main.transform;
		//Balance();
	}

	void Update()
	{

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;

		bool running = Input.GetKey(KeyCode.LeftShift);

		if (inputDir != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

			float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
			currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
		}
		else
		{
			currentSpeed = Mathf.Lerp(currentSpeed, 0, 1f/100f);
		}

		transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

		float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
	}
}