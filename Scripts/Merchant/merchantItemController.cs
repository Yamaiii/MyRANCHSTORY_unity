using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class merchantItemController : MonoBehaviour
{

    public MerchantItem thisItem;
    public Image buyImage;
    private void Awake() {
        GetComponent<Button>().onClick.AddListener(()=>
        {
            buyImage.gameObject.SetActive(true);
            BuyManager.Instance.merchantItem=thisItem;
        });
    }

}
