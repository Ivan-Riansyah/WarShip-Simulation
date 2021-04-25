using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleManager : MonoBehaviour
{
    public int role = 1;
    public List<GameObject> camera = new List<GameObject>();
    public List<Image>  crossHair= new List<Image>();

    GameObject canon;
    GameObject scout;
    BoatControllerScript boatController;
    RotateMissileLauncer rotateMissile;
    Shooting shooting;
    Scouting scouting;

    void Start()
    {
        canon = GameObject.FindGameObjectWithTag("Canon");
        scout = GameObject.FindGameObjectWithTag("Scouting");
        boatController = GetComponent<BoatControllerScript>();
        rotateMissile = canon.GetComponent<RotateMissileLauncer>();
        shooting = GetComponent<Shooting>();
        scouting = scout.GetComponent<Scouting>();
        RoleFunction(role);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("1"))
        {
            role = 1;
            RoleFunction(role);
        }

        else if (Input.GetKey("2"))
        {
            role = 2;
            RoleFunction(role);
        }

        else if (Input.GetKey("3"))
        {
            role = 3;
            RoleFunction(role);
        }
    }

    void RoleFunction(int role)
    {
        foreach (GameObject cam in camera)
        {
            cam.SetActive(false);
        }
        camera[role-1].SetActive(true);

        foreach (Image cross in crossHair)
        {
            cross.enabled = false;
        }
        crossHair[role-1].enabled = true;

        if (role == 1)
        {
            shooting.enabled = false;
            rotateMissile.enabled = false;
            boatController.enabled = true;
            scouting.enabled = false;
        }

        else if(role == 2)
        {
            shooting.enabled = true;
            rotateMissile.enabled = true;
            boatController.enabled = false;
            scouting.enabled = false;
        }

        else if (role == 3)
        {
            shooting.enabled = false;
            rotateMissile.enabled = false;
            boatController.enabled = false;
            scouting.enabled = true;
        }
    }
}
