using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Transform target;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //find player tag
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Get nav mesh agent and animator
        enemyAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Chase();
    }

    // Update is called once per frame
    void Update()
    {
        //this checks the distance between the enemy and player
        float distance = Vector3.Distance(transform.position, target.position);


        //check if player is within distance for chase
        if (distance > 2 && distance< 50)
        {
            ChasePlayerFar();
        }
        //attack player in range
        else if (distance < 1.5)
        {
            AttackPlayerInRange();

        }
        //idle is set if player is to far
        else if (distance > 50)
        {
            Idle();
        }

    }


    void Chase()
    {
        //Set walking animation to true
        anim.SetBool("Walking", true);
        anim.SetBool("Attacking", false);
        anim.SetBool("Idle", false);

        enemyAgent.isStopped = false;
        //stops within this distance from the player
        enemyAgent.stoppingDistance = 1.7f;


    }
    void AttackPlayerInRange()
    {
        //Attacking animation is set true 
        anim.SetBool("Walking", false);
        anim.SetBool("Attacking", true);
        anim.SetBool("Idle", false);
    }
    void ChasePlayerFar()
    {
        //Walking animation is set to true and set destination to player position
        enemyAgent.updatePosition = true;
        enemyAgent.SetDestination(target.position);
        anim.SetBool("Walking", true);
        anim.SetBool("Attacking", false);
        anim.SetBool("Idle", false);

    }
    void Idle()
    {
        //idle animation is set to true
        anim.SetBool("Walking", false);
        anim.SetBool("Attacking", false);
        anim.SetBool("Idle", true);
    }
}
