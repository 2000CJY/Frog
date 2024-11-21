using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float jumpForce = 10f;
	public float forwardForce = 5f;
	public float _speed = 1;
	private Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && GameManagers.instance.activate == true)
		{
			Jump();
		}

		if (Input.GetKey(KeyCode.W))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
			transform.position += Vector3.forward * Time.deltaTime * _speed;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
			transform.position += Vector3.back * Time.deltaTime * _speed;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
			transform.position += Vector3.left * Time.deltaTime * _speed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
			transform.position += Vector3.right * Time.deltaTime * _speed;
		}
	}

	void Jump()
	{
		Vector3 jumpVector = Vector3.up * jumpForce + transform.forward * forwardForce;
		rb.AddForce(jumpVector, ForceMode.Impulse);
	}
}
