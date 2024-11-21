using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    public Player player;
    public ConstraintController controller1;
	public ConstraintController controller2;
	public ConstraintController controller3;
	public ConstraintController controller4;

    public bool activate;

	void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        if (controller1.isLerping == true && controller2.isLerping == true && controller3.isLerping == true && controller4.isLerping == true)
        {
            activate = true;
        }
        else
        {
            activate = false;
        }
    }
}
