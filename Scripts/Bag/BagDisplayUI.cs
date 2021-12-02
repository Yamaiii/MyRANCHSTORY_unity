using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagDisplayUI : Singleton<BagDisplayUI>
{

    private void Start() {
        updateItemToUI();
    }

    public MyBag myBag;
    public GridInformation gridPrefab;
    public GameObject displayPoint;
    private UserController userController;

    /// <summary>
    /// 将物体数据显示在对应UI上
    /// </summary>
    /// <param name="item">需要显示的物体</param>
    public static void insertItemToUI(Item item)
    {
        GridInformation gridInformation=Instantiate(Instance.gridPrefab,Instance.displayPoint.transform);
        gridInformation.gridImage.sprite=item.itemImage;
        gridInformation.gridNum.text=item.itemNum.ToString();
    }

    public static void updateItemToUI()
    {
        for (int i = 0; i < Instance.displayPoint.transform.childCount; i++)
        {
            Destroy(Instance.displayPoint.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < Instance.myBag.itemList.Count; i++)
        {
            insertItemToUI(Instance.myBag.itemList[i]);
        }
    }

    private void Update() {
        for(int i=0;i<myBag.itemList.Count;i++)
        {
            if (myBag.itemList[i].itemNum<=0)
            {
                myBag.itemList.Remove(myBag.itemList[i]);
                userController.sub--;  
                updateItemToUI();
            }
        }
    }

    public void Register(UserController userController)
    {
        this.userController=userController;
    }
}
