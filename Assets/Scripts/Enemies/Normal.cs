using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : MonoBehaviour
{
    
    public float speed = 1;

    Rigidbody2D enemyBody;

    void Start() {
        enemyBody = GetComponent<Rigidbody2D>();

        enemyBody.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);

        Destroy(gameObject, 10);
    }

    void Update() {
        enemyBody.MoveRotation(enemyBody.rotation + 3);
    }

}
