using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Engine : MonoBehaviour
{
    public Elevator_Engine ee;
    public GameObject upButton;
    public GameObject stopButton;
    private bool soundEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("waitingForSound");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (soundEnd)
        {
            if (collision.gameObject.name == upButton.name)
            {
                ee.level = 1;
            }
            if (collision.gameObject.name == stopButton.name)
            {
                ee.level = 0;
            }
        }
        
    }

    IEnumerator waitingForSound()
    {
        yield return new WaitForSeconds(32.0f);
        soundEnd = true;
        Debug.Log("ENDDEDEDEDED");
    }
}
