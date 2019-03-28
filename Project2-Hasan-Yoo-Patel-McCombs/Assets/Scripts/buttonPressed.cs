using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPressed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "LeftControllerAnchor" || collision.gameObject.name == "RightControllerAnchor")
		{
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
		{

		}
	}
}
