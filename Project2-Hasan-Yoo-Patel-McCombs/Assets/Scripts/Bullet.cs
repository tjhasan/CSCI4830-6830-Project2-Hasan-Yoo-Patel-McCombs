using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float bulletLifeTime;
    public float bulletSpeed;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        bulletLifeTime -= Time.deltaTime;
        Debug.Log(bulletLifeTime);
        if (bulletLifeTime < 0)
        {
            Debug.Log("Destroying Rocket");
            Destroy(this.gameObject);
        }
        transform.Translate(0, 0, bulletSpeed);
        transform.position = transform.position + .5f * transform.forward;
	}

	void OnCollisionEnter(Collision collision)
	{
	 	if(collision.gameObject.name == "Target(Clone)")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameManager.targetCount--;
        }
	}
}
