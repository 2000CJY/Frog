using UnityEngine;

public class Player : MonoBehaviour
{
	int layerMask;
	public float distance;
	public float jumpForce = 10f; // ���� ���� �����ϴ� ����
	public float forwardForce = 5f; // ������ ���ư��� ���� �����ϴ� ����
	private Rigidbody rb; // Rigidbody ������Ʈ�� ������ ����

	void Start()
	{
		layerMask = LayerMask.GetMask("Ground");
		rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� �����ɴϴ�

		if (rb == null)
		{
			Debug.LogError("Rigidbody component is not found!");
		}
	}

	void Update()
	{
		RaycastHit hit;
		Vector3 rayDirection = Vector3.down;

		if (Physics.Raycast(transform.position, rayDirection, out hit, Mathf.Infinity, layerMask))
		{
			distance = Vector3.Distance(transform.position, hit.point);

			Debug.DrawRay(transform.position, rayDirection * distance, Color.red);
		}

		if (Input.GetKeyDown(KeyCode.Space) && distance < 0.5f) // �����̽� Ű�� ������ �� ����
		{
			Jump();
		}
	}

	void Jump()
	{
		Vector3 jumpVector = Vector3.up * jumpForce + transform.forward * forwardForce;
		rb.AddForce(jumpVector, ForceMode.Impulse);
	}
}
