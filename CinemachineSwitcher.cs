using UnityEngine;
using Cinemachine;
public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vrcam1;

    [SerializeField]
    private CinemachineVirtualCamera vrcam2;

    private bool overWorldCamera = true;
    // Start is called before the first frame update
   public void SwithCamera()
    {
        if (overWorldCamera)
        {
            vrcam1.Priority = 0;
            vrcam2.Priority = 1;

        }
        else
        {
            vrcam1.Priority = 1;
            vrcam2.Priority = 0;
        }
        overWorldCamera = !overWorldCamera;
    }
}
