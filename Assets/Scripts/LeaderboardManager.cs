using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{

    public TMP_InputField inputField;
    public Transform scores;

    Leaderboard leaderboard;

    void Awake() {
        leaderboard = GameObject.Find("Leaderboard").GetComponent<Leaderboard>();
        StartCoroutine(leaderboard.ChangeInputFieldToName(inputField));
        StartCoroutine(leaderboard.FetchHighscores(scores));
    }

}
