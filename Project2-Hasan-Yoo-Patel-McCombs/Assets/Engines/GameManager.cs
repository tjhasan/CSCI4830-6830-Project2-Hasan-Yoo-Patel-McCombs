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

    public Transform MiniGameStartAudio;
    public Transform MiniGameEndAudio;
    public Transform ExtremeAudio;
    //public GameObject textLvl1;
    //public GameObject textLvl1Loc;



    int level = 0;
    bool level1Played = false;
    bool level2Played = false;
    bool level3Played = false;
    bool levelExtPlayed = false;

    public TextMeshProUGUI gameText;
    float levelTime;
    float levelTimeLvl1 = 0;
    float levelTimeLvl2 = 0;
    float levelTimelvl3 = 0;
    float extremeLevelTime = 0;
    bool startTime = false;

    bool sound = false;
    
    
    //TextMesh textboxClone;

    private IEnumerator coroutine;
    // Start is called before the first frame update

    void Start()
    {
        //PlayerPrefs.SetFloat("bestTime, 0");
        originElv = Elevator.transform.position;
        gameText.text = "Level 1:    [N/a]\nLevel 2:    [N/A]\nLevel 3:    [N/A]\nExtreme:  [N/A] \nOverall Best Time: " + PlayerPrefs.GetFloat("bestTime");
        MiniGameEndAudio.transform.GetComponent<AudioSource>().Stop();
        MiniGameStartAudio.transform.GetComponent<AudioSource>().Stop();
        ExtremeAudio.transform.GetComponent<AudioSource>().Stop();

    }

    void fire()
    {
        Bullet b = Instantiate<Bullet>(bulletPrefab, bulletLoc.transform.position, bulletLoc.transform.rotation);
    }

    void miniGame()
    {
        if(level == 1)
        {
            MiniGameStartAudio.transform.GetComponent<AudioSource>().Play();
        }
        if (level == 1 || level == 2 || level == 3)
        {
            //Instantiate(bitGun, rightHand.transform.position, rightHand.transform.rotation);
            elv.level = 0;
            Vector3[] targetPos = new[] { new Vector3(-104.7494f, -0.2f, 155.03f), new Vector3(-104.7494f, -0.2f, 144.16f), new Vector3(-117.01f, -0.2f, 148.62f), new Vector3(-90.99f, -0.2f, 145.42f), new Vector3(-90.99f, -0.2f, 154.09f) };
            for (int i = 0; i < targetPos.Length; i++)
            {
                targetCount++;
                Instantiate(target, targetPos[i], Quaternion.identity);
            }
        }
    }

    /*public void checkHighScore() {
        if (PlayerPrefs.GetFloat("bestTime") == 0)
        {
            PlayerPrefs.SetFloat("bestTime", levelTimeLvl1);
        }

        if (levelTimeLvl1 < PlayerPrefs.GetFloat("bestTime"))
        {
            PlayerPrefs.SetFloat("bestTime", levelTimeLvl1);
        }

        if (levelTimeLvl2 < PlayerPrefs.GetFloat("bestTime"))
        {
            PlayerPrefs.SetFloat("bestTime", levelTimeLvl2);
        }

        if (levelTimelvl3 < PlayerPrefs.GetFloat("bestTime"))
        {
            PlayerPrefs.SetFloat("bestTime", levelTimelvl3);
        }

        if (extremeLevelTime < PlayerPrefs.GetFloat("bestTime"))
        {
            PlayerPrefs.SetFloat("bestTime", extremeLevelTime);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
       

        // if (level == 1) //&&gunpcikedup
        // {
        //     startTime = true;
        //  }
        //if (startTime)
        //{
        if (level == 1)//(level1Played == false)
        {
            if (targetCount != 0)
            {
                levelTime += Time.deltaTime;
                levelTimeLvl1 = levelTime;
                gameText.text = "Level 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [N/A]\nLevel 3:    [N/A]\nExtreme:  [N/A]  \nOverall Best Time: " + PlayerPrefs.GetFloat("bestTime");
                Debug.Log(PlayerPrefs.GetFloat("bestTime"));
            }
            else
            {
                levelTime = 0;
                if (PlayerPrefs.GetFloat("bestTime") == 0)
                {
                    PlayerPrefs.SetFloat("bestTime", levelTimeLvl1);
                }
                if (levelTimeLvl1 < PlayerPrefs.GetFloat("bestTime"))
                {
                    PlayerPrefs.SetFloat("bestTime", levelTimeLvl1);
                }
            }
        }
        
        else if (level == 2)
        {
            if (targetCount != 0)
            {
                levelTime += Time.deltaTime;
                levelTimeLvl2 = levelTime;
                gameText.text = "Level 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTimeLvl2 + "]\nLevel 3:    [N/A]\nExtreme:  [N/A]  \nOverall Best Time: " + PlayerPrefs.GetFloat("bestTime");
                Debug.Log("after lvl 1 " + PlayerPrefs.GetFloat("bestTime"));
            }
            else
            {
                levelTime = 0;
                if (levelTimeLvl2 < PlayerPrefs.GetFloat("bestTime"))
                {
                    PlayerPrefs.SetFloat("bestTime", levelTimeLvl2);
                }

            }
        }

        else if (level == 3)
        {
            if (targetCount != 0)
            {
                levelTime += Time.deltaTime;
                levelTimelvl3 = levelTime;
                gameText.text = "Level 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTimeLvl2 + "]\nLevel 3:    [" + levelTimelvl3 + "]\nExtreme:  [N/A] \nOverall Best Time: " + PlayerPrefs.GetFloat("bestTime");
                Debug.Log("after lvl 2 " + PlayerPrefs.GetFloat("bestTime"));
            }
            else
            {
                levelTime = 0;
                if (levelTimelvl3 < PlayerPrefs.GetFloat("bestTime"))
                {
                    PlayerPrefs.SetFloat("bestTime", levelTimelvl3);
                }
            }
        }

        else if (level == 4)
        {
            levelTime += Time.deltaTime;
            extremeLevelTime = levelTime;
            gameText.text = "Level 1:    [" + levelTimeLvl1 + "]\nLevel 2:    [" + levelTimeLvl2 + "]\nLevel 3:    [" + levelTimelvl3 + "]\nExtreme:  [" + extremeLevelTime + "] \nOverall Best Time: " + PlayerPrefs.GetFloat("bestTime");
        }

      //  }

        if (targetCount == 0)
        {//checking to see which level they are progressing to
            //if the gun exists and the game is over destroy the gun
            /*
            if (bitGun != null)
            {
                Destroy(bitGun);
            }
            */

            if ((level1Played == true && level2Played == false && level3Played == false) ||
               (level1Played == true && level2Played == true && level3Played == false) ||
               (level1Played == true && level2Played == true && level3Played == true && levelExtPlayed==false))
            {

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
            else if (Elevator.transform.position.y >= originElv.y + 135f && levelExtPlayed == false)
            {
                level = 4;
                levelExtPlayed = true;
                elv.level = 0;
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