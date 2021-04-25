using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMissileLauncher : MonoBehaviour
{
    public float turnSpeed = 50f;
    public Vector2 pitchMinMaxY = new Vector2(-45, 45);

    float rotationValueY;
    float angleY = 0;

    void Update()
    {
        rotationValueY = turnSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        angleY += rotationValueY;
        angleY = Mathf.Clamp(angleY, pitchMinMaxY.x, pitchMinMaxY.y);
        
        transform.localEulerAngles = new Vector3(0, angleY, 0);
    }
}
