using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Mew MerchantBag",menuName ="Bag/New MerchantBag")]
public class MerchantBag : ScriptableObject
{
    public List<MerchantItem> itemList=new List<MerchantItem>();
}
