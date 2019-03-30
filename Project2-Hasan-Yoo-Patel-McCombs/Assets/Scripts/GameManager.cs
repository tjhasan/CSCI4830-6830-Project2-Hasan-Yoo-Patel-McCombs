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

    public GameObject bitGun;
    public GameObject rightHand;

    float timeToFire;

    private bool gameFinished = false;

    Vector3 originElv;

    public static int targetCount = 0;
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
        Bullet b = Instantiate<Bullet>(bulletPrefab, bulletLoc.transform.position, bulletLoc.transform.rotation);
    }

    void miniGame()
    {
        if (level == 1 || level == 2 || level == 3)
        {
            Instantiate(bitGun, rightHand.transform.position, rightHand.transform.rotation);
            elv.level = 0;
            Vector3[] targetPos = new[] { new Vector3(-104.7494f, -0.2f, 155.03f) };//, new Vector3(-104.7494f, -0.2f, 144.16f), new Vector3(-117.01f, -0.2f, 148.62f), new Vector3(-90.99f, -0.2f, 145.42f), new Vector3(-90.99f, -0.2f, 154.09f) };
            for (int i = 0; i < 1; i++)
            {
                targetCount++;
                Instantiate(target, targetPos[i], Quaternion.identity);
            }

            // while (targetCount != 0)  //if beat stop time and set levelTime to 0
            // {
            //     elv.level = 0;
            // }
        }
    }

    // Update is called once per frame

    void Update()
    {
        Debug.Log(targetCount);

        if (level == 1) //&&gunpcikedup
        {
            startTime = true;
        }
        if (startTime)
        {
            if (level1Played == true)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTime + "]\nLevel 2:    [Timer TBD]\nLevel 3:    [Timer TBD]\nExtreme:  [Timer TBD] ";
            }

            else if (level1Played == true && level1Played == false)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTime + "]\nLevel 3:    [Timer TBD]\nExtreme:  [Timer TBD] ";
            }

            else if (level2Played == true && level3Played == false)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTimeLvl2 + "]\nLevel 3:    [" + levelTime + "]\nExtreme:  [Timer TBD] ";
            }

            else if (levelExtPlayed == false && level3Played == true)
            {
                levelTime += Time.deltaTime;
                gameText.text = "Name:      [Name writing TBD]\nLevel 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTimeLvl2 + "]\nLevel 3:    [" + levelTimelvl3 + "]\nExtreme:  [" + extremeLevelTime + "] ";
            }

        }

        if (targetCount == 0)
        {//checking to see which level they are progressing to
            if ((level1Played == true && level2Played == false && level3Played == false) ||
               (level1Played == true && level2Played == true && level3Played == false) ||
               (level1Played == true && level2Played == true && level3Played == true))
            {
                Debug.Log("hello");
                elv.level = 1;
            }

            if (Elevator.transform.position.y >= originElv.y + 10f && level1Played == false)
            {//after the elevator moves up 10 units level 1 starts
                level = 1;
                miniGame();
                level1Played = true;
            }
            else if (Elevator.transform.position.y >= originElv.y + 44f && level2Played == false)
            {//after the elevator moves up 44 units level 2 starts
                level = 2;
                miniGame();
                level2Played = true;
            }
            else if (Elevator.transform.position.y >= originElv.y + 78f && level3Played == false)
            {//after the elevator moves up 78 units level 3 starts
                level = 3;
                miniGame();
                level3Played = true;
            }
        }

        else
        {
            bitGun.transform.position = rightHand.transform.position;
            bitGun.transform.rotation = rightHand.transform.rotation;
            elv.level = 0;
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
               // Vector3 v = rightHand.transform.rotation.eulerAngles;
                //bitGun.transform.rotation = Quaternion.Euler(v.x, (rightHand.transform.rotation.y), v.z);
                bool bDown = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
                if (bDown == true)
                {
                    fire();
                }

            }
        }
    }
}