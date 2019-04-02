using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEngine : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public GameObject Door;
    public GameObject Elevator;
    public Transform WindSound;
    public Transform ExtremeAudio;
    private bool isTurn = false;
    public float time = 80f; //30 seconds for you


    // Start is called before the first frame update
    void Start()
    {
        WindSound.transform.GetComponent<AudioSource>().Stop();
        ExtremeAudio.transform.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Reach height of plank
        if(Elevator.transform.position.y >= 136)
        {
            if (!isTurn)
            {
                Door.transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
                if(Door.transform.rotation.y >= 0.0f)
                {
                    isTurn = true;
                }
            }
        }
        else
        {
            Door.transform.Rotate(Vector3.forward,0.0f);
            WindSound.transform.GetComponent<AudioSource>().Play();
            ExtremeAudio.transform.GetComponent<AudioSource>().Play();
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Play Audio Here -- Timer Over!!");
            WindSound.transform.GetComponent<AudioSource>().Play();
            ExtremeAudio.transform.GetComponent<AudioSource>().Play();
            time = 80f;
        }
    }


}
