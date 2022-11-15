using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public float spinSpeed = 1;

    void Update() {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }

}
