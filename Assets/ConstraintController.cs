using UnityEngine;

public class ConstraintController : MonoBehaviour
{
	public Player player;
	public GameObject frogLeg;
	public float lerpSpeed = 0.2f; // Lerp ���� �ӵ��� ������ �� �ִ� ����
	private Vector3 originalPosition;
	public bool isLerping = false; // Lerp ���� ������ ���θ� �����ϴ� ����

	void Start()
	{
		originalPosition = transform.position;
	}

	void Update()
	{
		if (player.distance >= 1f)
		{
			isLerping = true; // Lerp ����
		}

		if (isLerping)
		{
			// Lerp�� �̿��Ͽ� frogLeg.transform.position���� �̵��մϴ�.
			transform.position = Vector3.Lerp(transform.position, frogLeg.transform.position, lerpSpeed * Time.deltaTime);

			// �������� ���� �����ϸ� Lerp ������ �����մϴ�.
			if (Vector3.Distance(transform.position, frogLeg.transform.position) < 0.03f) // ���� ������ ��
			{
				isLerping = false;
				transform.position = frogLeg.transform.position; // ���� ��ġ ����
				originalPosition = frogLeg.transform.position;
			}


		}
		else
		{
			// player.distance�� 1���� ���� �� ���� ��ġ�� ����
			transform.position = originalPosition;
		}
	}
}
