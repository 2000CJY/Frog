using UnityEngine;

public class Player : MonoBehaviour
{
	int layerMask;
	public float distance;
	public float jumpForce = 10f; // 점프 힘을 조절하는 변수
	public float forwardForce = 5f; // 앞으로 나아가는 힘을 조절하는 변수
	private Rigidbody rb; // Rigidbody 컴포넌트를 저장할 변수

	void Start()
	{
		layerMask = LayerMask.GetMask("Ground");
		rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 가져옵니다

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

		if (Input.GetKeyDown(KeyCode.Space) && distance < 0.5f) // 스페이스 키를 눌렀을 때 점프
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
