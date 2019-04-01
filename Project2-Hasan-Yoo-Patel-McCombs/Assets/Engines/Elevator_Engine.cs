using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Engine : MonoBehaviour
{
    public float speed = 0;
    public int level = 0;
    public Transform StartAudio;
    public Transform ForceAudio;
    public GameObject UpButton;

    // Start is called before the first frame update
    void Start()
    {
        StartAudio.transform.GetComponent<AudioSource>().Play();
        ForceAudio.transform.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {//Have 4 levels of speed. 0 1 2 and 3, with 3 being the highest. Allow therapist to use arrow keys to also control speed.

        transform.position += Vector3.up * speed * Time.deltaTime; //actual movement of the elevator.

        //speeds final
        if (level == 0)
        {//level 1
            speed = 0;
        }

        if (level == 1)
        {//level 2
            speed = 2;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && level < 1 ||//Given that the speed is not currently at 1 or 0...
            OVRInput.GetDown(OVRInput.Button.One) && level < 1)//increase/decrease the level by 1.
        {//arrow keys are for therapist. Buttons are for the user
            level++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && level > 0 ||
            OVRInput.GetDown(OVRInput.Button.Three) && level > 0)
        {
            level--;
        }

        //Following code is used for the force stop of the session:
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) &&
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) &&
            OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) &&
            OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {//if all the triggers are squeezed together, then it resets the elevator
                level = 0;
            ForceAudio.transform.GetComponent<AudioSource>().Play();
                StartCoroutine("waitingForTransition");
        }

        //seperated inputs for readability
        if (Input.GetKeyDown(KeyCode.E))
        {
            level = 0;
            transform.position = new Vector3(1.111f, 0.824f, 0.573f);
        }
    }

    IEnumerator waitingForTransition()
    {
        yield return new WaitForSeconds(8.0f);
        Initiate.Fade("Survey Scene", Color.black, 0.5f);
    }

}

