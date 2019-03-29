using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public Transform bulletLoc;

    public Bullet bulletPrefab;

    public GameObject Elevator;

    public Elevator_Engine elv;

    public GameObject target;

    float timeToFire;

    private bool gameFinished = false;

    Vector3 originElv;

    public int targetCount = 0;
    public GameObject[] targetPos;
    //public GameObject textLvl1;
    //public GameObject textLvl1Loc;



    int level = 0;
    bool level1Played = false;
    bool level2Played = false;
    bool level3Played = false;
    bool levelExtPlayed = false;

    public TextMeshProUGUI gameText;
    float levelTime;
    float levelTimeLvl1;
    float levelTimeLvl2;
    float levelTimelvl3;
    float extremeLevelTime;
    bool startTime = false;




    //TextMesh textboxClone;



    private IEnumerator coroutine;







    // Start is called before the first frame update

    void Start()

    {
        originElv = Elevator.transform.position;

    }




    void fire()

    {
        Debug.Log("fired");
        Bullet b = Instantiate<Bullet>(bulletPrefab, bulletLoc.transform.position, bulletLoc.transform.rotation);

        Destroy(b.gameObject, 1.0f);


    }

    void miniGame()
    {
        Debug.Log("inMini");



        if (level == 1 || level == 2 || level == 3)
        {
            Debug.Log("in level");
            // Instantiate(textLvl1, textLvl1Loc.transform.position, textLvl1Loc.transform.rotation);
            elv.level = 0;
            Vector3[] targetPos = new[] { new Vector3(-104.7494f, -0.2f, 155.03f), new Vector3(-104.7494f, -0.2f, 144.16f), new Vector3(-117.01f, -0.2f, 148.62f), new Vector3(-90.99f, -0.2f, 145.42f), new Vector3(-90.99f, -0.2f, 154.09f) };
            for (int i = 0; i < 5; i++)
            {
                targetCount++;
                Instantiate(target, targetPos[i], Quaternion.identity);
                Debug.Log("created target");
            }

            // while (targetCount != 0)  //if beat stop time and set levelTime to 0
            // {
            //     elv.level = 0;
            // }
        }
    }


    // Update is called once per frame

    void Update() {

        if (level==1) //&&gunpcikedup
        {
            startTime = true;
        }
        if (startTime)
        {
            if (level1Played == false)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTime + "]\nLevel 2:    [Timer TBD]\nLevel 3:    [Timer TBD]\nExtreme:  [Timer TBD] ";
            }

            else if(level1Played==true && level1Played == false)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTimeLvl1 + "]\nLevel 2:    ["+levelTime+"]\nLevel 3:    [Timer TBD]\nExtreme:  [Timer TBD] ";
            }

            else if (level2Played == true && level3Played==false)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTimeLvl1 + "]\nLevel 2:    ["+ levelTimeLvl2 + "]\nLevel 3:    ["+levelTime+"]\nExtreme:  [Timer TBD] ";
            }

            else if(levelExtPlayed == false)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTimeLvl2 + "]\nLevel 3:    [" + levelTimelvl3 + "]\nExtreme:  ["+extremeLevelTime+"] ";
            }
            

        }
     if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("gunHeld");
            bool bDown = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
            if (bDown == true)
            {
                Debug.Log("trigger pulled");
                fire();
            }

        }  
        if (Elevator.transform.position.y >= originElv.y + 10f && level1Played==false)
        {
            level = 1;
            miniGame();           
            level1Played = true;
        }
        else if(Elevator.transform.position.y>=originElv.y + 44f && level2Played == false)
        {
            level=2;
            miniGame();
            level2Played = true;
        }
        else if(Elevator.transform.position.y>=originElv.y + 78f && level3Played == false)
        {
            level=3;
            miniGame();
            level3Played = true;
        }
    }


}

            
       // }



	


