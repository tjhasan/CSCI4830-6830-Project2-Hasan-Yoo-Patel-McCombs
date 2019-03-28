using System.Collections;
using System.Collections.Generic;
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

    public GameObject[] targets;

    public GameObject textLvl1;
    public GameObject textLvl1Loc;



    int level = 0;
    bool level1Played = false;
    bool level2Played = false;
    bool level3Played = false;






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

        Destroy(b.gameObject, 1.0f);


    }

    void miniGame()
    {

        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))

        {

            bool bDown = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);

            if (bDown == true)
            {
                fire();
            }

        }

        if (level == 1 || level ==2 || level == 3)
        {
           // Instantiate(textLvl1, textLvl1Loc.transform.position, textLvl1Loc.transform.rotation);
            elv.level = 0;
            Vector3[] targetPos = new[] { new Vector3(-105.28f, -92.62f, 146.82f), new Vector3(-94.51113f, -92.62f, 139.96f), new Vector3(-111.89f, -92.62f, 157.15f), new Vector3(-111.89f, -92.62f, 150.54f), new Vector3(-101.22f, -92.62f, 154.51f) };
            for (int i = 0; i < 5; i++)
            {
                Instantiate(target, targetPos[i], Quaternion.identity);

            }
            while (target != null)
            {
                elv.level = 0;
            }
        }
    }


    // Update is called once per frame

    void Update()

    {
        // Debug.Log("Elevator" + Elevator.transform.position.y);
        //Debug.Log("origin" + originElv.y);
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



	


