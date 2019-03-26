using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {
    public Transform[] Destination;
    public float speed = 1f;
    private int destPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 curPosition = /*transform.position*/;
        

        if (Vector3.Distance(transform.position, Destination[destPoint].position) > 1 )
        {
            Vector3 direction = (Destination[destPoint].transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.position += direction;
            //Debug.Log(Vector3.Distance(transform.position, Destination.position));

            // Finding the direction toward the destination
            Vector3 moveDirection = Destination[destPoint].position - transform.position;

            // Rotate the NPC toward the target
            Vector3 rotateDirection = Vector3.RotateTowards(transform.forward, moveDirection, 1, 0);
            transform.rotation = Quaternion.LookRotation(new Vector3(rotateDirection.x, 0, rotateDirection.z));

            Debug.DrawRay(transform.position, rotateDirection, Color.red);

        

        }
        else
        {
           
            destPoint = (destPoint + 1) % Destination.Length;
        }
    }
}
