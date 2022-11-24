using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public float spinSpeed = 200;
    public int direction = 1;
    public bool bounce = false;
    public float bounceMin = -90;
    public float bounceMax = 90;

    void Update() {
        transform.Rotate(0, 0, (spinSpeed * direction) * Time.deltaTime);
        
        if (bounce)
        {
            float angle = transform.eulerAngles.z;
            if (angle > 180) angle -= 360;

            if (direction > 0 && angle >= bounceMax) direction = -1;
            else if (direction < 0 && angle <= bounceMin) direction = 1;
        }
    }

}
