using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDownScript : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == go)
        {
            Debug.Log("Button Down Pressed");
        }
    }
}
