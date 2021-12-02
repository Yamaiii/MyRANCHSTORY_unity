using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Mew MyBag",menuName ="Bag/New MyBag")]

public class MyBag : ScriptableObject
{
    public List<Item> itemList=new List<Item>();
}
