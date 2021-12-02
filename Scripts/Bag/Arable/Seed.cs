using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [Tooltip("生长周期")]
    public int growthCycle;
    public GameObject halfState;
    public GameObject lastState;
    public int resultValue;
    public Item result;
}
