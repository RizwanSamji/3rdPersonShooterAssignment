using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    // Variable for the character's Animator component
    private Animator anim;
    // Variable for the character's Character Controller component
    private CharacterController controller;
    // float variable for dampening speed values
    public float transitionTime = .25f;
    private int destPoint = 0;

    public Transform[] Destination;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();

        // Assign character's Animator to 'anim' variable
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && Destination != null &&
            // Check if the NPC is at the destination
            Vector3.Distance(transform.position, Destination[destPoint].position) > 1 )
        {
            //Debug.Log(Vector3.Distance(transform.position, Destination.position));

            // Finding the direction toward the destination
            Vector3 moveDirection = Destination[destPoint].position - transform.position;

            // Rotate the NPC toward the target
            Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, moveDirection, 1, 0);
            transform.rotation = Quaternion.LookRotation(new Vector3(rotateDirection.x, 0, rotateDirection.z));

            Debug.DrawRay(transform.position, rotateDirection, Color.red);

            //// Set zSpeed float as 'zSpeed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
            anim.SetFloat("zSpeed", Vector3.Distance(transform.position, Destination[destPoint].position), transitionTime, Time.deltaTime);

            ///////////////////////////////////////////////////////////////////////////////////////////
            //// Direct movement of the character without animation
            //// If we set the speed it changes the magnitude of the move direction
            //moveDirection = moveDirection * speedLimit;
            //controller.Move(moveDirection * Time.deltaTime);
            ///////////////////////////////////////////////////////////////////////////////////////////
            
        }
        else
        {
            //// Set zSpeed float as 'zSpeed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
            anim.SetFloat("zSpeed", 0, transitionTime, Time.deltaTime);
            destPoint = (destPoint + 1) % Destination.Length;
        }
       
            
    }

    
}
