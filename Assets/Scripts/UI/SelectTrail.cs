using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectTrail : MonoBehaviour
{

    public float widthStart = 10;
    public float widthEnd = 5;

    TrailRenderer trail;

    void Awake() {
        trail = GetComponent<TrailRenderer>();
    }

    public void Show(Transform textPos) {
        transform.position = textPos.position + new Vector3(widthStart, 0);
        trail.time = float.PositiveInfinity;
        transform.position = textPos.position + new Vector3(widthEnd, 0);
    }

    public void Hide() {
        trail.time = 0;
    }

}
