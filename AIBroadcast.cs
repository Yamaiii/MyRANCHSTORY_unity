using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个类要单例
public class AIBroadcast : MonoBehaviour {
    public bool noonTime = false;
    private void Update()
    {
        if (true/*休息时间*/)
        {
            noonTime = true;
        }
    }

}
