using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquiggleShot : MonoBehaviour
{

    public float frequency = 1;
    public float maxFrequency = 25;
    public float speed = 10;
    private float currentFrequency = 0;

    Rigidbody2D bulletBody;

    void Start() {
        bulletBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        bulletBody.rotation += frequency;
        bulletBody.velocity = transform.up * speed;
        currentFrequency += frequency;
        if (currentFrequency >= maxFrequency || currentFrequency <= -maxFrequency)
        {
            frequency = -frequency;
        }
    }

}
