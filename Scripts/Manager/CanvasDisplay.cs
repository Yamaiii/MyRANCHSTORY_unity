using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDisplay : MonoBehaviour
{
    public Text moneyDisplay;
    public Text fatigueValueDisplay;
    public Text hungerValueDisplay;

    public Image playerBag;
    public Image playerInf;

    public int _tag=1;

    private void ShowInf()
    {
        moneyDisplay.text=PlayerInformation.Instance.money.ToString();
        fatigueValueDisplay.text=PlayerInformation.Instance.fatigueValue.ToString();
        hungerValueDisplay.text=PlayerInformation.Instance.hungerValue.ToString();
    }
    private void Update() 
    {
        ShowInf();
    }

}
