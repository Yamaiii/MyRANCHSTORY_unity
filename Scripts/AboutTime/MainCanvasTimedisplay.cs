using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasTimedisplay : MonoBehaviour
{
    public Text timedisplaytext;
    private void Update() {
        timedisplaytext.text=Timetxt.Instance.hour_Time+":"+Timetxt.Instance.min_Time;
    }
}
