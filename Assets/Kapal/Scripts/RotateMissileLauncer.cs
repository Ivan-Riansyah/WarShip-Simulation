using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMissileLauncer : MonoBehaviour
{
    public float turnSpeed = 50f;
    public Vector2 pitchMinMaxY = new Vector2(-45, 45);
    //public Vector2 pitchMinMaxX = new Vector2(-45, 45);


    float rotationValueY;
    float angleY = 0;

    /*float rotationValueX;
    float angleX = 0;*/

    void Update()
    {
        rotationValueY = turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        angleY += rotationValueY;
        angleY = Mathf.Clamp(angleY, pitchMinMaxY.x, pitchMinMaxY.y);
        /*rotationValueX = turnSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        angleX -= rotationValueX;
        angleX = Mathf.Clamp(angleX, pitchMinMaxX.x, pitchMinMaxX.y);*/
        transform.localEulerAngles = new Vector3(0, 0, angleY);
    }
}
