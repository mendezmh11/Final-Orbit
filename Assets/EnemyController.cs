using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;

    private EnemyState enemy_State;

    public float walk_Speed = 0.5f;
    public float run_Speed = 4f;

    public float chase_Distance = 7f;
    private float current_Chase_Distance;
    public float attack_Distance = 1.8f;
    public float chase_After_Attack_Distance = 2f;

    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_For_This_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;
    private float attack_Timer;

    private Transform target;

    private void Awake()
    {
        enemy_Anim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        enemy_State = EnemyState.PATROL;

        patrol_Timer = patrol_For_This_Time;

        attack_Timer = wait_Before_Attack;

        current_Chase_Distance = chase_Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_State == EnemyState.PATROL) {
            Patrol();
        }
        if (enemy_State == EnemyState.CHASE){
            Chase();
        }
        if(enemy_State == EnemyState.ATTACK)
        {
            Attack();
        }
    }
    void Patrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = walk_Speed;

        patrol_Timer += Time.deltaTime;
        if(patrol_Timer > patrol_For_This_Time)
        {
            SetNewRandomDestination();

            patrol_Timer = 0f;
        }
    }

    void Chase()
    {

    }
    void Attack()
    {

    }
    void SetNewRandomDestination()
    {
        float rand_Radius = Random.RandomRange(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        navAgent.SetDestination(navHit.position);
    }
}//class





































