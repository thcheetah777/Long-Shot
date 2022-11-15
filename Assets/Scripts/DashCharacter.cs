using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DashCharacter : MonoBehaviour
{

    Image image;
    PointsManager pointsManager;

    void Start() {
        image = GetComponent<Image>();
        pointsManager = GameObject.Find("Points Manager").GetComponent<PointsManager>();
    }

    void Update() {
        if (pointsManager.points < 0)
        {
            image.color = Color.white;
            transform.localPosition = new Vector3(0 - pointsManager.scoreText.text.Length * 26, transform.localPosition.y, 0);
        } else
        {
            image.color = Color.clear;
        }
    }

}
