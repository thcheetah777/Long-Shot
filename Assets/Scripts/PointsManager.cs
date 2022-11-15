using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    
    public float points;
    public TMP_Text scoreText;

    void Awake() {
        GameObject pointsManagerFound = GameObject.Find("Points Manager");
        if (pointsManagerFound != gameObject)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update() {
        if (!scoreText && SceneManager.GetActiveScene().name == "Game") scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
    }

    public void ResetPoints() {
        points = 0;
    }

    public void AddPoint(float pointsIncrement) {
        points += pointsIncrement;
        scoreText.text = points.ToString();
    }

}
