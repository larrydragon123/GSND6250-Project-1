using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    //NPC with walk to waypoints until the last one, one each waypoints npc will lookaround for players,if see player for 3 seconds game over
    public Transform[] waypoints;
    public int currentWaypoint = 0;
    public float speed = 1.0f;
    
    public void Start()
    {
        
    }



    public void MoveToNextPoint()
    {
        if(currentWaypoint < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            if (transform.position == waypoints[currentWaypoint].position)
            {
                currentWaypoint++;
            }
        }
        else
        {
            currentWaypoint = 0;
        }
    }
}
