using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个类要单例
public class AIBroadcast : Singleton<AIBroadcast> {
    public bool noonTime = false;
    int freetime=12;
    private void Update()
    {
        if (Timetxt.Instance.hour_Time==freetime)
        {
            noonTime = true;
        }
        else
        {
            noonTime=false;
        }
    }

}
