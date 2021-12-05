using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<string,Transform> mapPoint;//地图上主要的点位的位置信息和名字 （用来主角的导航，瞬移，npc的导航）
    public List<Transfrom> pointPos;//存放位置信息
    public StarterAssetsInputs input;
    public ThirdPersonController thirdPersonController;
    public void InTheOpenUI(bool b)
    {
        thirdPersonController.isAniIng=b;
        thirdPersonController.LockCameraPosition=b;
        Cursor.lockState=b?CursorLockMode.None:CursorLockMode.Locked;
    }
    private void Awake()
    {
        //位置赋值
        foreach (var item in pointPos)
        {
            mapPoint.Add(item.name, item.transform);
        }
    }
}
