using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniController : Singleton<PlayerAniController>
{
    private Animator playerAni;
    [HideInInspector]
    public bool isWatering=false;
    protected override void Awake()
    {
        base.Awake();
        playerAni=GetComponent<Animator>();
    }
    private float updateTime;
    private void Update() 
    {
        Relax();
        Watering();
    }

    private void Relax()
    {
        updateTime+=Time.deltaTime;
        if (updateTime>=22||playerAni.GetFloat("Speed")>=1.8f||!playerAni.GetBool("Grounded"))
        {
            updateTime=0;
        }
        playerAni.SetFloat("UpdateTime",updateTime);
    }

    private void PlantSeed()
    {

    }

    private void Watering()
    {
        playerAni.SetBool("Watering",isWatering);
        isWatering=false;
    }
}
