using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : Singleton<GameManager>
{
    public StarterAssetsInputs input;
    public ThirdPersonController thirdPersonController;
    public void InTheOpenUI(bool b)
    {
        thirdPersonController.isAniIng=b;
        thirdPersonController.LockCameraPosition=b;
        Cursor.lockState=b?CursorLockMode.None:CursorLockMode.Locked;
    }
}
