using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyManager : Singleton<BuyManager>
{
    public InputField input;
    public MerchantItem merchantItem;
    private int sumPrice;
    private int amount;
    private Button[] buttons=new Button[4];

    override protected void Awake() {
        base.Awake();
        buttons=GetComponentsInChildren<Button>();
    }
    private void Start() {
        findButton();
        amount=0;
        sumPrice=0;
    }
    public void buyTheItem()
    {
        sumPrice=merchantItem.itemPrice*amount;
        if (PlayerInformation.Instance.money>=sumPrice)
        {
            PlayerInformation.Instance.money-=sumPrice;
            merchantItem.playerItem.itemNum+=amount;
        }
        else
        {
            print("购买失败");
        }
        gameObject.SetActive(false);
    }
    private void findButton()
    {
        foreach (Button item in buttons)
        {
            if (item.name=="add")
            {
                item.onClick.AddListener(()=>
                {
                    amount++;
                });
            }
            if (item.name=="decline")
            {
                item.onClick.AddListener(()=>
                {
                    if (amount>0)
                    {
                        amount--;
                    }
                });
            }
            if (item.name=="buy")
            {
                item.onClick.AddListener(()=>
                {
                    buyTheItem();
                });
            }
            if (item.name=="cancel")
            {
                item.onClick.AddListener(()=>
                {
                    gameObject.SetActive(false);
                });
            }
        }
    }
    private void Update() {
        input.text=amount.ToString();
    }
}
