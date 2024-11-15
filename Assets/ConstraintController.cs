using UnityEngine;

public class ConstraintController : MonoBehaviour
{
	public Player player;
	public GameObject frogLeg;
	public float lerpSpeed = 0.2f; // Lerp 보간 속도를 조절할 수 있는 변수
	private Vector3 originalPosition;
	public bool isLerping = false; // Lerp 동작 중인지 여부를 저장하는 변수

	void Start()
	{
		originalPosition = transform.position;
	}

	void Update()
	{
		if (player.distance >= 1f)
		{
			isLerping = true; // Lerp 시작
		}

		if (isLerping)
		{
			// Lerp를 이용하여 frogLeg.transform.position으로 이동합니다.
			transform.position = Vector3.Lerp(transform.position, frogLeg.transform.position, lerpSpeed * Time.deltaTime);

			// 목적지에 거의 도달하면 Lerp 동작을 종료합니다.
			if (Vector3.Distance(transform.position, frogLeg.transform.position) < 0.03f) // 작은 값으로 비교
			{
				isLerping = false;
				transform.position = frogLeg.transform.position; // 최종 위치 설정
				originalPosition = frogLeg.transform.position;
			}


		}
		else
		{
			// player.distance가 1보다 작을 때 원래 위치로 설정
			transform.position = originalPosition;
		}
	}
}
