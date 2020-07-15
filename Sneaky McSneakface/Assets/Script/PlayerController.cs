using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public float playerNoiseDistance;
    public GameObject bullet;
    public Transform firepoint;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        pawn.Move(vertical);
        pawn.Rotate(horizontal);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(bullet, firepoint.position, firepoint.rotation); 



        }
    }
}
