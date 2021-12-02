using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : Singleton<PlayerInformation>
{
    public int money=10000;
    public int fatigueValue=100;//疲劳值
    public int hungerValue=100;//饥饿值
}
