using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scouting : MonoBehaviour
{
    public Camera cam;
    public float speedH, speedV = 2.0f;
    public Vector2 pitchMinMax = new Vector2(0, 30);
    public float zoomSpd;
    public float smoothTurn = 1f;
    public List<GameObject> ship = new List<GameObject>();
    public List<Image> uiDisplay = new List<Image>();
    public GameObject scoutBG;


    private float mouseScrollInput;
    private float yaw, pitch = 0.0f;
    private float camFOV;

    private void Start()
    {
        camFOV = cam.fieldOfView;
        foreach (Image cross in uiDisplay)
        {
            cross.enabled = false;
        }
        uiDisplay[0].enabled = true;
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X") * smoothTurn;
        pitch -= speedV * Input.GetAxis("Mouse Y") *smoothTurn;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");
        camFOV -= mouseScrollInput * zoomSpd;
        camFOV = Mathf.Clamp(camFOV, 15, 60);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, zoomSpd);

        if (Input.GetButtonDown("Fire1"))
        {
            ScoutTarget();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(GameObject ships in ship)
            {
                ships.SetActive(false);
                uiDisplay[1].enabled = false;
                uiDisplay[0].enabled = true;
                scoutBG.SetActive(false);
            }
        }
    }

    void ScoutTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Player")
            {
                return;
            }
            else if (hit.transform.tag == "Kapal1")
            {
                ship[0].SetActive(true);
                Debug.Log(hit.transform.name);
                uiDisplay[0].enabled = false;
                uiDisplay[1].enabled = true;
                scoutBG.SetActive(true);
            }
            else if (hit.transform.tag == "Enemy")
            {
                ship[1].SetActive(true);
                Debug.Log(hit.transform.name);
                uiDisplay[0].enabled = false;
                uiDisplay[1].enabled = true;
                scoutBG.SetActive(true);
            }
            else
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}