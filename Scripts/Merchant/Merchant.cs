using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public MerchantBag merchantBag;
    public Image thisStore;
    public Button exit;
    private void Start() {
        exit.onClick.AddListener(()=>
        {
            thisStore.gameObject.SetActive(false);
            GameManager.Instance.InTheOpenUI(false);
        });
    }
    public void OpenStore()
    {
        GameManager.Instance.InTheOpenUI(true);
        thisStore.gameObject.SetActive(true);
        SayHi();
    }

    public void SayHi()
    {
        //当角色来买东西时，问候问候主角
    }
}
