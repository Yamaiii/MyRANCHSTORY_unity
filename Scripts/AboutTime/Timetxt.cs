using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 时间类
/// 现实换算比例 1：10
/// </summary>
public class Timetxt : Singleton<Timetxt>
{
    
    public int year_Time = 2000;//年
    public int day_Time = 1;//日
    public int hour_Time = 12;//小时
    public int moon_Time = 1;//月
    public int min_Time = 0;//分钟
    private float lerptime = 1;//用来每秒增加分钟的计时器

    void Update()
    {
        Time_Growth();
        // print((int)Time.time);
    }
    private void LateUpdate()
    {
        lerptime += Time.deltaTime;
    }
    private void Time_Growth()
    {

        if (min_Time < 60 && lerptime > 1)
        {
            lerptime = 0;
            min_Time = min_Time + 1;
        }
        else if (min_Time >= 60)
        {
            min_Time = 0;
            hour_Time++;
        }

        if (hour_Time >= 24)
        {
            hour_Time = 0;
            day_Time++;
        }
        if (year_Time % 4 == 0 && year_Time % 100 != 0)
        {
            if (moon_Time == 2)
            {
                if (day_Time > 29)
                {
                    day_Time = 1;
                    moon_Time++;
                }
            }
        }
        else
        {
            if (moon_Time == 2)
            {
                if (day_Time > 28)
                {
                    day_Time = 1;
                    moon_Time++;
                }
            }
        }
        if (moon_Time < 8 && moon_Time % 2 == 0)
        {
            if (day_Time > 30)
            {
                day_Time = 1;
                moon_Time++;
            }
        }
        else if (moon_Time < 8)
        {
            if (day_Time > 31)
            {
                day_Time = 1;
                moon_Time++;
            }
        }
        if (moon_Time > 7 && moon_Time % 2 == 0)
        {
            if (day_Time > 31)
            {
                day_Time = 1;
                moon_Time++;
            }
        }
        else if (moon_Time < 8)
        {
            if (day_Time > 30)
            {
                day_Time = 1;
                moon_Time++;
            }
        }
        if (moon_Time > 12)
        {
            moon_Time = 1;
            year_Time++;
        }
    }
}
