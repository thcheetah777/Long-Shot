using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class Leaderboard : MonoBehaviour
{

    public bool loginDone = false;
    public int leaderboardID = 8887;
    public string playerID;

    void Start() {
        // GameObject pointsManagerFound = GameObject.Find("Leaderboard");
        // if (pointsManagerFound != gameObject)
        // {
        //     Destroy(gameObject);
        // } else
        // {
        //     DontDestroyOnLoad(gameObject);
        // }
        
        StartCoroutine(Login());
    }

    private IEnumerator Login() {
        loginDone = false;
        LootLockerSDKManager.StartGuestSession((response) => {
            if (response.success)
            {
                print("Logged in!");
                playerID = response.player_id.ToString();
                loginDone = true;
            } else
            {
                print("Log in failed");
                loginDone = true;
            }
        });
        yield return new WaitWhile(() => !loginDone);
    }

    public IEnumerator SubmitHighscore(int score) {
        yield return new WaitUntil(() => loginDone);
        LootLockerSDKManager.SubmitScore(playerID, score, leaderboardID, (response) => {
            if (response.success)
            {
                print("Highscore submitted!");
            } else
            {
                print("Highscore submission failed");
            }
        });
    }

    public IEnumerator FetchHighscores(Transform scoresUI) {
        yield return new WaitUntil(() => loginDone);
        LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0, (response) => {
            if (response.success)
            {
                print("Highscores fetched!");
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    string username = scores[i].player.name;
                    int score = scores[i].score;

                    GameObject scoreUI = scoresUI.GetChild(i).gameObject;
                    TMP_Text scoreUIText = scoreUI.GetComponent<TMP_Text>();
                    scoreUIText.text = "<b>" + (i + 1) + "</b>. " + username + "    <i>" + score + "</i>";
                }
            } else
            {
                print("Fetching highscores failed");
            }
        });
    }

    public IEnumerator ChangeUsernameCoroutine(string newName) {
        yield return new WaitUntil(() => loginDone);
        LootLockerSDKManager.SetPlayerName(newName, (response) => {
            if (response.success)
            {
                print("Changed name to: " + newName);
            } else
            {
                print("Changin name failed");
            }
        });
    }

    public IEnumerator ChangeInputFieldToName(TMP_InputField input) {
        yield return new WaitUntil(() => loginDone);
        LootLockerSDKManager.GetPlayerName((response) => {
            if (response.success)
            {
                print(response.name);
                input.text = response.name != "" ? response.name : "Anonymous";
            } else
            {
            }
        });
    }

    public void ChangeUsername(TMP_InputField input) {
        StartCoroutine(ChangeUsernameCoroutine(input.text));
    }

}
