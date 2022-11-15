using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyan : MonoBehaviour
{
    public float speed = 10;

    Rigidbody2D enemyBody;

    void Start() {
        enemyBody = GetComponent<Rigidbody2D>();

        enemyBody.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void Update() {
        enemyBody.MoveRotation(enemyBody.rotation + 5);
    }
}
