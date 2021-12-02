using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using StarterAssets;

public class PlayerInteraction : Singleton<PlayerInteraction>
{
    protected ThirdPersonController playerThirdPersonController;
    private MyBag myBag;
    public event Action<GameObject,string> OnF_keyClicked;
    [Tooltip("交互距离")]
    public float _interactionDic;
    
    Keyboard keyboard=Keyboard.current;
    RaycastHit hit;
    public GameObject promptObj;
    private int hCheck=0;
    private int vCheck=0;
    private int pickCheck=0;
    private int isPrompt;
    [HideInInspector]
    public Item consumable;

    [HideInInspector]
    public Seed _seed;
    [HideInInspector]
    public Watering _watering;
    
    [HideInInspector]
    public bool isItem=false;//判断是否是Item：可否拾取

    private void Start() {
        _interactionDic=5f;
    }
    /// <summary>
    /// 玩家的F 按键交互
    /// </summary>
    void F_keyControl()
    {
        Ray ray=Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0f));//从屏幕中间发射射线
        if(Physics.Raycast(ray,out hit,_interactionDic))
        {
            if (keyboard.fKey.wasPressedThisFrame&&hit.collider!=null)
            {
                OnF_keyClicked?.Invoke(hit.transform.gameObject,hit.collider.tag);
                hCheck=0;
            }
            if (hit.collider.tag=="Door"||hit.collider.tag=="Merchant")
            {
                hCheck=1;
            }
        }
        else
        {
            hCheck=0;
        }
       
    }
    private void Update() {
        F_keyControl();
        isPrompt=vCheck+hCheck+pickCheck;
        if (isPrompt>0)
        {
            promptObj.SetActive(true);
        }
        else
        {
            promptObj.SetActive(false);
        }
        PickupCheck();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if (keyboard.fKey.wasPressedThisFrame&&hit!=null)
        {
            if (hit.collider.tag=="Arable")
            {   
                //种植
                if (_seed!=null&&hit.collider.GetComponent<ArableControal>().isPlant==false)
                {
                    hit.collider.GetComponent<ArableControal>().Plant(_seed);
                    hit.collider.GetComponent<ArableControal>().isPlant=true;
                    consumable.itemNum--;
                }
                if (hit.collider.GetComponent<ArableControal>().isMature==true)
                {
                    hit.collider.GetComponent<ArableControal>().Harvest();
                }
                //浇水
                if (_watering!=null&&hit.collider.GetComponent<ArableControal>().isWet==false)
                {
                    hit.collider.GetComponent<ArableControal>().isWet=true;
                    PlayerAniController.Instance.isWatering=true;
                }
            }
        }
        if (hit.collider.tag=="Arable")
        {
            vCheck=1;
        }
        else
        {
            vCheck=0;
        }
    }
    private void PickupCheck()
    {
        if (isItem)
        {
            pickCheck=1;
        }
        else
        {
            pickCheck=0;
        }
    }

}
