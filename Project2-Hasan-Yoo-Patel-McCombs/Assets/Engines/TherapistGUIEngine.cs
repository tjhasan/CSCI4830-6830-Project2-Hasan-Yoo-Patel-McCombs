using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistGUIEngine : MonoBehaviour
{

    public Elevator_Engine elv;
    public Transform ForceAudio;
    public Transform ExtremeAudio;
    public Transform MiniGameStartAudio;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ContinueButtonClicked()
    {
        elv.level++;
    }

    public void StopButtonClicked()
    {
        elv.level = 0;
    }

    public void ForceQuitButtonClicked()
    {
        elv.level = 0;
        MiniGameStartAudio.transform.GetComponent<AudioSource>().Stop();
        ExtremeAudio.transform.GetComponent<AudioSource>().Stop();
        ForceAudio.transform.GetComponent<AudioSource>().Play();
        StartCoroutine("waitingForTransition");
    }

    IEnumerator waitingForTransition()
    {
        yield return new WaitForSeconds(8.0f);
        Initiate.Fade("Survey Scene", Color.black, 0.5f);
    }
}
