using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingOverlay : MonoBehaviour
{

    Leaderboard leaderboard;

    void Start() {
        leaderboard = GameObject.Find("Leaderboard").GetComponent<Leaderboard>();
    }

    void Update() {
        gameObject.SetActive(!leaderboard.loginDone);
    }

}
