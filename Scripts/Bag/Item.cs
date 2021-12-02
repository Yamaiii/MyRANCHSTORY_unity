using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Kind
{
    seed,
    watering,
    food
}
//快捷创建物品数据
[CreateAssetMenu(fileName ="New Item",menuName ="Bag/New Item")]
public class Item : ScriptableObject
{
    public Kind itemKind;
    public bool _isConsumable;
    public string itemName;
    public Sprite itemImage;
    public int itemNum;

    public GameObject itemObj;
    [TextArea]//变成更大的文本输入
    public string itemInfo;
}
