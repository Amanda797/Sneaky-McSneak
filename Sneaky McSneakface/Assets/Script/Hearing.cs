using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{
    public float hearingRadius;
    public Pawn pawn;
    public GameObject searchLocation;
    public bool CanHear()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < hearingRadius + GameManager.instance.player.GetComponent<PlayerController>().playerNoiseDistance)
        {
            //I can hear the player
            Debug.Log("I can hear the player");
            searchLocation = new GameObject();
            searchLocation.transform.position = GameManager.instance.player.transform.position;
            pawn.target = searchLocation.transform;
            return true;
        }
        return false;
    }



}

