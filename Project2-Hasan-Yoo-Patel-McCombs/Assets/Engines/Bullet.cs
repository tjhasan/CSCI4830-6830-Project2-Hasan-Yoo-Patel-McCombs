using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float bulletLifeTime;
    public float bulletSpeed;
    public Transform gunSound;

    // Start is called before the first frame update
    void Start()
    {
        gunSound.transform.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime < 0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(0, 0, bulletSpeed);
        transform.position = transform.position + .5f * transform.forward;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Target(Clone)")
        {
            GameManager.targetCount--;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}