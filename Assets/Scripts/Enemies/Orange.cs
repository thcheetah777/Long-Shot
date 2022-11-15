using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{

    public float speed = 0.1f;

    Transform playerTransform;
    Rigidbody2D orangeBody;

    void Start() {
        orangeBody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Destroy(gameObject, 50);
    }

    void FixedUpdate() {
        orangeBody.position = Vector2.Lerp(orangeBody.position, playerTransform.position, speed);
        
        transform.up = playerTransform.position - transform.position;
    }

}
