using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.position = transform.position + .5f * transform.forward;
	}

	private void OnCollisionEnter(Collision collision)
	{
	 	if (this.gameObject.name=="Target")
		{
			Destroy(this.gameObject);
            Destroy(collision.gameObject);
			GameManager.targetCount--;
		}

		else{
			Destroy(collision.gameObject);
			Debug.Log("here");
		}
	}
}
