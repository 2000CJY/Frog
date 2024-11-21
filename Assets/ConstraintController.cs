using Unity.VisualScripting;
using UnityEngine;

public class ConstraintController : MonoBehaviour
{
	public GameObject frogLeg;
	public float lerpSpeed = 1f;
	private Vector3 originalPosition;
	public bool isLerping = true;
	public float frogdistance;

	void Start()
	{
		originalPosition = transform.position;
	}

	void Update()
	{
		frogdistance = Vector3.Distance(frogLeg.transform.position, transform.position);
		if (frogdistance >= 1f)
		{
			isLerping = false;
		}

		if (isLerping == false)
		{
			transform.position = Vector3.Lerp(transform.position, frogLeg.transform.position, lerpSpeed * Time.deltaTime);

			if (frogdistance < 0.1f)
			{
				isLerping = true;
				transform.position = frogLeg.transform.position;
				originalPosition = frogLeg.transform.position;
			}
		}
		else
		{
			transform.position = originalPosition;
		}
	}
}
