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
public class NPCController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator ani;
    public NPCKinds kind;
    public Transform homePos;
    public int wakeUpTime;
    public Transform drinkPos;
    public Transform workPos;
    public bool isWork = true;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (AIBroadcast.Instance.noonTime)
        {
            //切换行走
            agent.destination = homePos.position;
            if (Vector3.Distance(transform.position,homePos.position)<agent.stoppingDistance)
            {
                //切换动作：睡觉
            }
        }
        if (Timetxt.Instance.day_Time>=6)
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
        if (kind = NPCKinds.FARMER || kind = NPCKinds.NOMAD)
        {

        }
    }

    private void ToDrink()
    {
        //切换动作至行走，走到酒馆
        agent.destination = drinkPos.position;
        if (Vector3.Distance(transform.position,drinkPos.position)<agent.stoppingDistance)
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
        if (true)
        {
            //切换动作
            i = Random.Range(0,10);
        }
        if (Timetxt.Instance.hour_Time==14)
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
