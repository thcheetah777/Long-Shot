using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{

    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    void OnEnable() {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.unscaledDeltaTime * dampingSpeed;
        } else {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void Shake(float duration, float magnitude) {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }

}
