using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Engine : MonoBehaviour
{
    private float speed = 0;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        Transform startPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {//Have 3 levels of speed. 1 2 and 3, with 3 being the highest. Allow therapist to use arrow keys to also control speed.
        //Below code used for the movement of the elevator
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))//replace keyboard keys with in game physical buttons. Arrow buttons allowed for therapist.
        {
            speed = 5;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            speed = 0;
        }

        //Following code is used for the force stop of the session:
        //if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) &&
        //   OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) &&
        //   OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) &&
        //   OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        //{
        //    transform.position = startPosition;
        //}

        if(Input.GetKeyDown(KeyCode.E))
        {
            speed = 0;
            transform.position = startPosition;
        }
    }
}
