using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    static public void DieScene() {
        SceneManager.LoadScene("End");
    }

    static public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

}
