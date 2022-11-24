using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveShot : MonoBehaviour
{

    public float speed = 10;
    public int direction = 1;
    public float curveAmount = 5;
    public float curveDelay = 0.5f;
    public float curveTime = 0.5f;
    public float curveAngle = 0;
    public bool curve = false;

    Rigidbody2D bulletBody;

    void Start() {
        bulletBody = GetComponent<Rigidbody2D>();
        StartCoroutine(Curve());
    }

    void Update() {
        bulletBody.velocity = transform.up * speed;
        if (curve)
        {
            bulletBody.rotation += curveAmount * direction;
            curveAngle += curveAmount * direction;
        }
    }

    private IEnumerator Curve() {
        yield return new WaitForSeconds(curveDelay);
        curve = true;
        yield return new WaitUntil(() => direction > 0 ? curveAngle > 180 : curveAngle < -180);
        curve = false;
    }

}
