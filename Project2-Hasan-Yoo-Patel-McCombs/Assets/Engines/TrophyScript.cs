using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    public Transform CongratsSound;
    public Transform CongratsText;
    public GameObject rightHand;
    private bool grabbed = false;
    private bool playSound = false;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        CongratsSound.transform.GetComponent<AudioSource>().Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            this.transform.position = rightHand.transform.position;
            this.transform.rotation = rightHand.transform.rotation;
            StartCoroutine("waitingForTransition");
        }
        if (playSound)
        {
            Instantiate(CongratsText);
            CongratsSound.transform.GetComponent<AudioSource>().Play();
            playSound = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == rightHand.gameObject)
        {
            if (!grabbed)
            {
                grabbed = true;
                playSound = true;
            }
        }
    }


    IEnumerator waitingForTransition()
    {
        yield return new WaitForSeconds(10.0f);
        Initiate.Fade("Survey Scene", Color.black, 0.5f);
    }
}
