using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneLoader.PlayGame();
        }
    }

}
