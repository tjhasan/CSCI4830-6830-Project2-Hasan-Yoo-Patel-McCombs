using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    public Transform CongratsSound;
    public Transform CongratsText;

    // Start is called before the first frame update
    void Start()
    {
        CongratsSound.transform.GetComponent<AudioSource>().Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(CongratsText);
            CongratsSound.transform.GetComponent<AudioSource>().Play();
            StartCoroutine("waitingForTransition");
        }
    }

    IEnumerator waitingForTransition()
    {
        yield return new WaitForSeconds(0.5f);
        Initiate.Fade("Survey Scene", Color.black, 0.5f);
    }
}
