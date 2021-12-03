using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : Singleton<GameManager>
{
    public Dictionary<string,Transform> mapPoint;//��ͼ����Ҫ�ĵ�λ��λ����Ϣ������ ���������ǵĵ�����˲�ƣ�npc�ĵ�����
    public List<Transfrom> pointPos;//���λ����Ϣ
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
        //λ�ø�ֵ
        foreach (var item in pointPos)
        {
            mapPoint.Add(item.name, item.transform);
        }
    }
}
