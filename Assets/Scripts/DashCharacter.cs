using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCharacter : MonoBehaviour
{

    Player player;
    Image image;

    void Start() {
        image = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        if (player.points < 0)
        {
            image.color = Color.white;
            transform.localPosition = new Vector3(0 - player.scoreText.text.Length * 26, transform.localPosition.y, 0);
        } else
        {
            image.color = Color.clear;
        }
    }

}
