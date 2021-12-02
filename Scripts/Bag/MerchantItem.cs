using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//快捷创建物品数据
[CreateAssetMenu(fileName ="New MerchantItem",menuName ="Bag/New MerchantItem")]
public class MerchantItem : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemPrice;
    [TextArea]
    public string itemInfo;
    public Item playerItem;

}
