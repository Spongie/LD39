using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour 
{
    public float AggroRange = 6f;
    public float SuicideRange = 2f;
    public GameObject Player;
    public bool isChasing = false;
    float ChasingSpeed = 8f;
    float DefaultSpeed;
    NavMeshAgent agent;
    StateManagaer stateManager;
    public Transform MyTransform;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        stateManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateManagaer>();

        DefaultSpeed = stateManager.EnemyBaseStats.Speed;
        ChasingSpeed = DefaultSpeed + 3;
        GetComponent<Health>().SetHealth(stateManager.EnemyBaseStats.Health);
    }

    void Update () 
	{
        if (stateManager.IsDead)
        {
            StopAgent();
            return;
        }

        var playerDistance = Mathf.Abs(Vector3.Distance(Player.transform.position, agent.transform.position));

        if (playerDistance < AggroRange && false)
        {
            if (!isChasing)
                StopAgent();

            isChasing = true;

            agent.SetDestination(Player.transform.position);
            agent.speed = ChasingSpeed;
            agent.isStopped = false;

            if (playerDistance < SuicideRange)
            {
                GameObject.FindGameObjectWithTag("PowerStation").GetComponent<PowerStation>().CurrentHealth -= 10;
                Destroy(gameObject);
            }
        }
        else if (playerDistance > AggroRange && isChasing)
        {
            StopAgent();
            ChaseStation();

        }
        else if (!agent.hasPath)
            ChaseStation();

        if (Vector3.Distance(MyTransform.position, agent.destination) < 4)
        {
            GameObject.FindGameObjectWithTag("PowerStation").GetComponent<PowerStation>().CurrentHealth -= 10;
            Destroy(gameObject);
        }
    }

    private void ChaseStation()
    {
        agent.speed = DefaultSpeed;
        agent.SetDestination(GameObject.FindGameObjectWithTag("PowerStation").GetComponent<PowerStation>().AttackTarget.position);
        agent.isStopped = false;
    }

    private void StopAgent()
    {
        if (!agent.isStopped)
            agent.isStopped = true;
    }

    private void OnDrawGizmos()
    {
        if (stateManager != null && stateManager.DrawAggroRanges)
            Gizmos.DrawWireSphere(transform.position, AggroRange);
    }
}