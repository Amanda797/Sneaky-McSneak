using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
    
{
    public float sightRadius;
    public Pawn pawn;
    public GameObject searchLocation;
    public float viewAngle;

    public bool CanSee()
    {
        //Distance between AI and player is less than sight radius
        if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < sightRadius)
        {
            //if player is in view angle 
            
            if (Vector3.Angle(transform.position, GameManager.instance.player.transform.position) < viewAngle / 2)
            {
                //raycast to player
                Vector3 directionToPlayer = GameManager.instance.player.transform.position - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer);

                if (hit.collider.tag == "Player")
                {
                    searchLocation = new GameObject();
                    searchLocation.transform.position = GameManager.instance.player.transform.position;
                    pawn.target = searchLocation.transform;
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }
        return false;


    }

}
