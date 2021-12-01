using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCKinds
{
    MERCHANT,
    FARMER,
    NOMAD
}
public class NPCTry_302 : MonoBehaviour {
    NavMeshAgent agent;
    Animator ani;
    public Transform homePos;
    public int wakeUpTime;
    public Vector3 drinkPos;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }
    private void ToDrink()
    {
        agent.destination = drinkPos;
        //开喝
    }

    private void FreeTime()
    {
        int i;
        if (true/*如果到了他起床的点*/)
        {
            //切换动作
            i = Random.Range(0,10);
        }+
        switch (i)
        {
            case 1:
                ToDrink();
                break;
        }
    }

}
