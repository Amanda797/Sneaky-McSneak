﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieControl : Controller
{


    public enum state
    {
        patrol, attack, search, chase
    }

    public state currentState;

    [Header("patrolling")]
    public List<Transform> waypoints;
    public int patrolIndex;
    public float closeEnough;
    
    [Header("Attacking")]
    public float AttackRange;
    
    [Header("Hearing")]
    public Hearing hearing;
    [Header("Sight")]
    public Sight sight;

    void changeState(state newState)
    {
        currentState = newState;
    }



    // Update is called once per frame
    void Update()
    {

        if (pawn.target != null)
        {
            pawn.Move(1);
            pawn.RotateToward(pawn.target.position - transform.position);

        }

        switch (currentState)
        {
            case state.attack:
                Attack();
                //if (sight.CanSee())
                //{
                //    changeState(state.search); 
                //}
                break;
            case state.chase:
                Chase();
                //if (IsInAttackRange())
                //{
                //    changeState(state.attack);
                //}
                break;
            case state.patrol:
                Patrol();
                if (hearing.CanHear())
                {
                    changeState(state.search);
                }

                break;
            case state.search:
                Search();
                if (Vector3.Distance(transform.position, pawn.target.position) < closeEnough && !sight.CanSee())
                {
                    changeState(state.patrol);
                }
                break;
        }

    }

    void Attack()
    {

    }

    public bool IsInAttackRange()
    {
     if (Vector2.Distance(transform.position, pawn.target.position) < AttackRange)
        {
            return true;
        }
     else
        {
            return false;
        }
    }
    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, pawn.target.position, pawn.speed * Time.deltaTime);
    }





    void Patrol()
    {
        pawn.target = waypoints[patrolIndex];

        if (Vector3.Distance(transform.position, pawn.target.position) < closeEnough)
        {
            //check if we are on the last index of the list
            if (patrolIndex < waypoints.Count - 1)
            {
                patrolIndex++;
            }
            else
            {
                patrolIndex = 0;
            }
        }
    }





    void Search()
    {
        
        
    }
}

