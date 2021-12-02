using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class UserController : MonoBehaviour
{
    public RawImage playerInfo;
    private bool isInfo=false;
    private GameObject doorRotaRoot;
    private StarterAssetsInputs _input;
    private ThirdPersonController thirdPersonController;
    public MyBag myBag;
    Keyboard keyboard=Keyboard.current;
    [Header("界面背包")]
    public GameObject interfaceBag;
    public Image _main;
    public Image _left;
    public Image _right;
    public int sub=0;
    private int leftSub=0;
    private int rightSub=0;
    private GameObject handItem;
    private void Awake() {

    }
    void Start()
    {
        PlayerInteraction.Instance.OnF_keyClicked+=OpenDoor;
        PlayerInteraction.Instance.OnF_keyClicked+=OpenStore;
        _input=GetComponent<StarterAssetsInputs>();
        thirdPersonController=GetComponent<ThirdPersonController>();
        BagDisplayUI.Instance.Register(this);
    }

    void Update()
    {
        
        if (_input.isbKey)
        {
            BagDisplayUI.updateItemToUI();
            GameManager.Instance.InTheOpenUI(!isInfo);
            interfaceBag.SetActive(isInfo);
            isInfo=!isInfo;
            playerInfo.gameObject.SetActive(isInfo);
        }
        _input.isbKey=false;
        InterfaceBag();
        HandItemToPlayer();
    }

    public void OpenDoor(GameObject hitobj,string hitTag)
    {
        if (hitTag=="Door")
        {
            hitobj.GetComponent<DoorController>().StateChange();
        }
    }
    public void OpenStore(GameObject hitobj,string hitTag)
    {
        if (hitTag=="Merchant")
        {
            hitobj.GetComponent<Merchant>().OpenStore();
        }
    }

    private void InterfaceBag()
    {
        if (sub<0)
        {
            sub=myBag.itemList.Count-1;
        }
        if (sub>myBag.itemList.Count-1)
        {
            sub=0;
        }
        if (leftSub<0)
        {
            leftSub=myBag.itemList.Count-1;
        }
        else
        {
            leftSub=sub-1;
        }
        if (rightSub>myBag.itemList.Count-1)
        {
            rightSub=0;
        }
        else
        {
            rightSub=sub+1;
        }
        if (leftSub>=0&&rightSub<=myBag.itemList.Count-1)
        {
            _main.sprite=myBag.itemList[sub].itemImage;
            _left.sprite=myBag.itemList[leftSub].itemImage;
            _right.sprite=myBag.itemList[rightSub].itemImage;     
        }
        if (_input.isQKey)
        {
            --sub;
        }
        _input.isQKey=false;
        if (_input.isEKey)
        {
            ++sub;
        }
        _input.isEKey=false;
    }

    private void HandItemToPlayer()
    {
        if (sub>0&&sub<myBag.itemList.Count)
        {
            PlayerInteraction.Instance._seed=myBag.itemList[sub].itemKind==Kind.seed?myBag.itemList[sub].itemObj.GetComponent<Seed>():null;
            PlayerInteraction.Instance._watering=myBag.itemList[sub].itemKind==Kind.watering?myBag.itemList[sub].itemObj.GetComponent<Watering>():null;
            PlayerInteraction.Instance.consumable=myBag.itemList[sub]._isConsumable?myBag.itemList[sub]:null;
        }
    }

}
