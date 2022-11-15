using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndManager : MonoBehaviour
{

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    PointsManager pointsManager;
    Leaderboard leaderboard;

    void Start() {
        pointsManager = GameObject.Find("Points Manager").GetComponent<PointsManager>();
        leaderboard = GameObject.Find("Leaderboard").GetComponent<Leaderboard>();
        
        finalScoreText.text = pointsManager.points.ToString();

        if (pointsManager.points > PlayerPrefs.GetFloat("High Score", 0))
        {
            highScoreText.text = "New Highscore!";
            PlayerPrefs.SetFloat("High Score", pointsManager.points);
            StartCoroutine(leaderboard.SubmitHighscore((int)pointsManager.points));
        } else
        {
            highScoreText.text = "Your highscore is " + PlayerPrefs.GetFloat("High Score", 0);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoader.PlayGame();
        }
    }

}
