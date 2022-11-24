using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowRing : MonoBehaviour
{

    public float rotationSpeed = 100;
    public float scaleSpeed = 25;
    public float scaleMax = 10;
    public int scaleDirection = 1;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        transform.localScale += (Vector3.one / scaleSpeed) * scaleDirection;

        if (transform.localScale.x >= scaleMax && scaleDirection > 0) scaleDirection = -1;
        if (transform.localScale.x <= 0) Destroy(gameObject);
    }

}
