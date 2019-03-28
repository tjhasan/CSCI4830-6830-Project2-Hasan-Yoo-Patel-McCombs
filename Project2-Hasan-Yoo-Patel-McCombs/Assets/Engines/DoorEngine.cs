using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEngine : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public GameObject Door;
    public GameObject Elevator;
    private bool isTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }


}
