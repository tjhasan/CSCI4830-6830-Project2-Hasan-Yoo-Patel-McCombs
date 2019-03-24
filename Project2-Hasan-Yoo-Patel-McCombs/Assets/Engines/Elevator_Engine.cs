using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Engine : MonoBehaviour
{
    public float speed = 0;
    public int level = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {//Have 4 levels of speed. 0 1 2 and 3, with 3 being the highest. Allow therapist to use arrow keys to also control speed.
        //Below code used for the movement of the elevator

        transform.position += Vector3.up * speed * Time.deltaTime;

        if (level == 0)
        {//level 1
            speed = 0;
        }

        if (level == 1)
        {//level 2
            speed = 2;
        }

        if (level == 2)
        {//level 3
            speed = 5;
        }

        if (level == 3)
        {//level 4
            speed = 10;
        }

        //speeds not final
        if (Input.GetKeyDown(KeyCode.UpArrow) && level < 3 ||//replace keyboard keys with in game physical buttons. Arrow buttons allowed for therapist.
            OVRInput.GetDown(OVRInput.Button.One) && level < 3)
        {
            level++;
            Debug.Log(level);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && level > 0 ||
            OVRInput.GetDown(OVRInput.Button.Three) && level > 0)
        {
            level--;
            Debug.Log(level);
        }

        //Following code is used for the force stop of the session:
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) &&
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) &&
            OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) &&
            OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
                level = 0;
                transform.position = new Vector3(1.111f, 0.824f, 0.573f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            level = 0;
            transform.position = new Vector3(1.111f, 0.824f, 0.573f);
        }
    }
}