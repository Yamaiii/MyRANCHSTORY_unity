using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
NOTE:
StateNum:
    1:Walk
    2:Eating
    0:Stand
    4:Sleep
*/
public enum AnimalStates
{
    Walk,
    Eating,
    Stand,
    Sleep,
    Run
}
public class AnimalController : MonoBehaviour
{
    //------动作代号常量---------//
    private const int isWalk=1;
    private const int isEating=2;
    private const int isStand=0;
    private const int isSleep=3;
    private const int isRun=4;
    //--------------------------//
    [Tooltip("动物每次移动的范围")]
    public float patrolRange;
    public float sightRadius;
    private NavMeshAgent agent;
    public AnimalStates _state;
    private Animator ani;
    private Vector3 wayPoint;
    private Vector3 newPoint;
    private Vector3 startPoint;
    public Transform eatingPoint;
    private void Awake() {
        agent=GetComponent<NavMeshAgent>();
        ani=GetComponent<Animator>();
    }
    private void Start() {
        _state=AnimalStates.Walk;
        wayPoint=transform.position;
        newPoint=transform.position;
        startPoint=transform.position;
    }
    private void Update() {
        SwitchState();
        // print(_state);
        // print(wayPoint);
    }

    private void SwitchState()
    {
        switch (_state)
        {
            //Walk
            //-------------------------//
            case AnimalStates.Walk:
                ani.SetInteger("StateNum",isWalk);
                if (FoundPlayer())
                {
                    Invoke("SetWalk",10f);
                    _state=AnimalStates.Stand;
                }
                if (Vector3.Distance(wayPoint,transform.position)<=agent.stoppingDistance)
                {
                    int rangeNum=Random.Range(1,10);
                    GetRandomState(rangeNum);
                    GetNewPoint();
                }
                else
                {
                    agent.destination=wayPoint;
                }
                break;
            //Stand
            //-------------------------//
            case AnimalStates.Stand:
                agent.destination=transform.position;
                ani.SetInteger("StateNum",isStand);
                break;
            //Sleep
            //-------------------------//
            case AnimalStates.Sleep:
                agent.destination=startPoint;
                if (Vector3.Distance(startPoint,transform.position)<=agent.stoppingDistance)
                {
                    ani.SetInteger("StateNum",isSleep);
                }
                break;
            //Eating
            //-------------------------//
            case AnimalStates.Eating:
                if (Vector3.Distance(eatingPoint.position,transform.position)<=1.5f)
                {
                    ani.SetInteger("StateNum",isEating);
                }
                break;
            //Run
            //-------------------------//
            case AnimalStates.Run:
                ani.SetInteger("StateNum",isRun);
                if (FoundPlayer())
                {
                    Invoke("SetWalk",10f);
                    _state=AnimalStates.Stand;
                }
                if (Vector3.Distance(wayPoint,transform.position)<=agent.stoppingDistance)
                {
                    int rangeNum=Random.Range(1,10);
                    GetRandomState(rangeNum);
                    GetNewPoint();
                }
                else
                {
                    agent.destination=wayPoint;
                }
                break;
            //-------------------------//
        }
    }

    private bool FoundPlayer()
    {

        var colliders=Physics.OverlapSphere(transform.position,sightRadius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                // transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.transform.position-transform.position),10f*Time.deltaTime);
                return true;
            }
        }
        return false;
    }

    private void GetNewPoint()
    {
        float randomX=Random.Range(-patrolRange,patrolRange);
        float randomZ=Random.Range(-patrolRange,patrolRange);

        newPoint=new Vector3(transform.position.x+randomX,transform.position.y,transform.position.z+randomZ);
        NavMeshHit navMeshHit;
        // newPoint=GetRandomPoint();\
        wayPoint=NavMesh.SamplePosition(newPoint,out navMeshHit,patrolRange,NavMesh.AllAreas)?navMeshHit.position:transform.position;
    }

    //取消使用的烘焙区域随机取点，不删除，说不定以后有用
    #region 
    // public Vector3 GetRandomPoint()
    // {
    //     NavMeshTriangulation navMeshDate=NavMesh.CalculateTriangulation();//获取已经烘焙的地图的顶点集合
    //     int t=Random.Range(0,navMeshDate.indices.Length-3);
    //     Vector3 point=Vector3.Lerp(navMeshDate.vertices[navMeshDate.indices[t]],navMeshDate.vertices[navMeshDate.indices[t+1]],Random.value);
    //     point=Vector3.Lerp(point,navMeshDate.vertices[navMeshDate.indices[t+2]],Random.value);
    //     return point;
    // }
    #endregion

    private void GetRandomState(int stayTime)
    {
        int n=Random.Range(1,10);
        if (n>=8)
        {
            _state=AnimalStates.Stand;
            Invoke("SetWalk",stayTime);
        }
        else if (n==7)
        {
            _state=AnimalStates.Sleep;
            Invoke("SetWalk",stayTime*10);
        }
        else if (n==6)
        {
            _state=AnimalStates.Run;
        }
        else
        {
            _state=AnimalStates.Walk;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,patrolRange);
        Gizmos.DrawWireSphere(transform.position,sightRadius);
    }
    private void SetWalk()
    {
        _state=AnimalStates.Walk;
    }


}
