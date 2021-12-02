using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对们进行控制，如开门关门
/// </summary>
public class DoorController : MonoBehaviour
{
    private GameObject rotaRoot;
    private bool isClose=true;
    private float rotaSpeed=10f;
    private bool change=false;
    public void StateChange()
    {
        change=true;
    }
    private void Update() 
    {
        if(change&&isClose)
        {
            transform.RotateAround(rotaRoot.transform.position,Vector3.up,-Time.deltaTime*rotaSpeed);
        }
        if (change&&!isClose)
        {
            transform.RotateAround(rotaRoot.transform.position,Vector3.up,Time.deltaTime*rotaSpeed);
        }
        if (Mathf.Abs(transform.localEulerAngles.y-290f)<1&&isClose)
        {
            change=false;
            isClose=!isClose;
        }
        if (Mathf.Abs(transform.localEulerAngles.y)<1&&!isClose)
        {
            change=false;
            isClose=!isClose;
        }
    }
    private void Start() {
        Transform[] children=GetComponentsInChildren<Transform>();
        foreach (var item in children)
        {
            if (item.name=="RotaRoot")
            {
                rotaRoot=item.gameObject;
            }
        }
        rotaSpeed=90f;
    }
}
