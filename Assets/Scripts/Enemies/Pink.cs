using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink : MonoBehaviour
{

    public float speed = 5;
    public float targetAngle = 0;
    public List<GameObject> trailColliders = new List<GameObject>();

    Rigidbody2D enemyBody;

    void Start() {
        enemyBody = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirection());
    }

    void Update() {
        enemyBody.MoveRotation(Mathf.LerpAngle(enemyBody.rotation, targetAngle, 0.1f));
    }

    void FixedUpdate() {
        enemyBody.AddRelativeForce(Vector2.up * speed);
    }

    private IEnumerator ChangeDirection() {
        while (true)
        {
            yield return new WaitForSeconds(2);
            targetAngle = Random.Range(0, 360);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Bullet")) {
            foreach (var trailCollider in trailColliders) Destroy(trailCollider);
        }
    }
}
