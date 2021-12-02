using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArableControal : MonoBehaviour
{
    public bool isPlant=false;//是否已经被种植
    public bool isWet=false;//是否已经浇水
    public bool isMature=false;
    public MyBag myBag;
    private GameObject growthSeed;
    private int growthCycle;
    //种植时的时间
    private int plantDay;
    private int plantMoon;
    private int plantYear;
    //成熟的日子
    private int[] lastTime=new int[3];
    //半成熟的日子
    private int[] halfTime=new int[3];
    private Seed _seed;
    private Vector3 plantPoint;
    private void Start() {
        plantPoint=new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    public void Plant(Seed _seed)
    {
        this._seed=_seed;
        growthSeed=GameObject.Instantiate(_seed.gameObject,plantPoint,Quaternion.identity);
        growthCycle=_seed.growthCycle;
        plantDay=Timetxt.Instance.day_Time;
        plantMoon=Timetxt.Instance.moon_Time;
        plantYear=Timetxt.Instance.year_Time;
    }

    private void Growth()
    {
        lastTime=plantTimeGrowth(plantYear,plantMoon,plantDay,growthCycle);
        halfTime=plantTimeGrowth(plantYear,plantMoon,plantDay,growthCycle/2);
        if (Timetxt.Instance.day_Time==halfTime[2])
        {
            Destroy(growthSeed);
            growthSeed=GameObject.Instantiate(_seed.halfState,plantPoint,Quaternion.identity);
        }
        if (Timetxt.Instance.day_Time==lastTime[2])
        {
            Destroy(growthSeed);
            growthSeed=GameObject.Instantiate(_seed.lastState,plantPoint,Quaternion.identity);
            isMature=true;
        }
    }
    private void Update() {
        if (isPlant&&isWet)
        {
            Growth();
        }
    }
    
    public void Harvest()
    {
        isMature=false;
        isPlant=false;
        isWet=false;
        Destroy(growthSeed);
        if (!myBag.itemList.Contains(_seed.result))
        {
            myBag.itemList.Add(_seed.result);
        }
        _seed.result.itemNum+=_seed.resultValue;
        _seed=null;
    }
    

    /// <summary>
    /// 计算他的成熟日子
    /// </summary>
    /// <param name="year">当时的年</param>
    /// <param name="moon">当时的月</param>
    /// <param name="day">当时的天</param>
    /// <param name="growthCycle">生长周期</param>
    /// <returns>growthCycle后的日子</returns>
    private int[] plantTimeGrowth(int year,int moon,int day,int cycle)
    {
        //                 0    1    2
        int[] matureTime={year,moon,day+cycle};
        if (year%4==0&&year%100!=0)
        {
            if (moon==2)
            {
                if (day+cycle>29)
                {
                    matureTime[2]=day+cycle-29;
                    matureTime[1]=3;
                    return matureTime;
                }
            }
        }
        else if(moon==2)
        {
            if (day+cycle>28)
            {
                matureTime[2]=day+cycle-28;
                matureTime[1]=3;
                return matureTime;
            }
        }
        if (moon==4||moon==6||moon==9||moon==11)
        {
            if (day+cycle>30)
            {
                matureTime[2]=day+cycle-30;
                matureTime[1]++;
                return matureTime;
            }
        }
        else if (moon!=2&&moon!=12)
        {
            if (day+cycle>31)
            {
                matureTime[2]=day+cycle-31;
                matureTime[1]++;
                return matureTime;
            }
        }
        else if(moon!=2)
        {
            if (day+cycle>31)
            {
                matureTime[2]=day+cycle-31;
                matureTime[1]=1;
                matureTime[0]++;
                return matureTime;
            }
        }
        return matureTime;
    }
    
}
