using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{

    public float ringDelay = 1;
    public float waitDelay = 1;
    public GameObject yellowRingPrefab;

    Rigidbody2D enemyBody;

    void Start() {
        enemyBody = GetComponent<Rigidbody2D>();
        StartCoroutine(RingLoop());
    }

    private IEnumerator RingLoop() {
        while (true)
        {
            yield return new WaitForSeconds(ringDelay);
            StartCoroutine(Ring());
        }
    }

    private IEnumerator Ring() {
        Vector2 previousVelocity = enemyBody.velocity;
        enemyBody.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitDelay);

        Instantiate(yellowRingPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(waitDelay);
        enemyBody.velocity = previousVelocity;
    }

}
