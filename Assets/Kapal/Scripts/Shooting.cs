using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using EZCameraShake;


public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public Camera camera;
    public VisualEffect muzzleFlash;
    public GameObject firePoint;
    public GameObject missileGameObject;

    private Quaternion rotation;
    private Vector3 direction;
    private GameObject missileSpawn;
    RaycastHit hit;

    void Start()
    {
        missileSpawn = missileGameObject;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            /*if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity))
            {
                 if(hit.transform.tag == "Kapal1")
                {
                    return;
                }
            }*/
            
            SpawnMissile();
        }
    }

    void SpawnMissile()
    {
        GameObject vfx;
        //spellAudio.Play();

        CameraShaker.Instance.ShakeOnce(2f, 4f, 0.1f, 1.5f);
        muzzleFlash.Play();
        RotateToDirection(gameObject, hit.point);
        vfx = Instantiate(missileSpawn, firePoint.transform.position, Quaternion.identity);
        vfx.transform.rotation = Quaternion.LookRotation(-firePoint.transform.right, firePoint.transform.up);
    }

    void RotateToDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
    }
}
