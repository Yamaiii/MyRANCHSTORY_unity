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
    public Transform workPos;
    public bool isWork = true;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        if (true/*如果AI广播说到了休息的点*/)
        {
            //切换行走
            agent.destination = homePos.position;
            if (Vector3.Distance(transform.position,homePos.position)<agent.stoppingDistance)
            {
                //切换动作：睡觉
            }
        }
        if (true/*如果是周末*/)
        {
            FreeTime();
        }
        else
        {
            WorkingDay();
        }
    }

    private void WorkingDay()
    {
        //切换动作
        agent.destination = workPos.position;
        //切换工作姿势和状态
        isWork = true;
    }

    private void ToDrink()
    {
        //切换动作至行走，走到酒馆
        agent.destination = drinkPos;
        if (Vector3.Distance(transform.position,drinkPos)<agent.stoppingDistance)
        {
            //切换动作喝酒
        }
        //开喝
    }

    private void ToSea()
    {
        //切换动作
    }

    private void FreeTime()
    {
        isWork = false;
        int i=0;
        if (true/*如果到了他起床的点*/)
        {
            //切换动作
            i = Random.Range(0,10);
        }
        if (true/*如果到了下午切换时间的点*/)
        {
            i = Random.Range(0,10);
        }
        switch (i)
        {
            case 0:
                break;
            case 1:
                ToDrink();
                break;
            case 2:
                ToSea();
                break;
        }
    }

}
