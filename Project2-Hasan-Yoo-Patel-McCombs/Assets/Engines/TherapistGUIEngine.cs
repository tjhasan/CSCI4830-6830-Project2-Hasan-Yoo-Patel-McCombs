using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapistGUIEngine : MonoBehaviour
{

    public Elevator_Engine elv;

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
        elv.transform.position = new Vector3((float)-101.264, (float)-90.365, (float)160.646);
    }
}
