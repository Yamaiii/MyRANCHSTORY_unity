using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SceneItem : MonoBehaviour
{
    //该物体的数据
    public Item item;
    //放入的背包：主角背包
    public MyBag myBag;
    private Keyboard keyboard=Keyboard.current;

    private void OnTriggerStay(Collider other) {
        if (other.tag=="Player")
        {
            PlayerInteraction.Instance.isItem=true;
            if(keyboard.fKey.wasPressedThisFrame)
            {
                if (!myBag.itemList.Contains(item))
                {
                    myBag.itemList.Add(item);
                }
                item.itemNum++;
                BagDisplayUI.updateItemToUI();
                PlayerInteraction.Instance.isItem=false;
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag=="Player")
        {
            PlayerInteraction.Instance.isItem=false;
        }
    }
}
