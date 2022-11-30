using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Powerup : MonoBehaviour
{

    public float speed = 2;
    public GameObject powerupNameText;

    private ShotType randomShot;

    Rigidbody2D powerupBody;
    AudioManager audioManager;
    Camera cam;
    Transform canvas;

    void Start() {
        powerupBody = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        canvas = GameObject.Find("Canvas").transform;
        audioManager = GameObject.Find("Game Controller").GetComponent<AudioManager>();
        Vector2 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        powerupBody.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
            audioManager.PlaySound(audioManager.powerup);
            while (true) {
                randomShot = (ShotType)Random.Range(0, System.Enum.GetValues(typeof(ShotType)).Length);
                if (randomShot != collider.GetComponent<Player>().shotType) break;
            }
            collider.GetComponent<Player>().shotType = randomShot;

            GameObject powerupNameGameObject = Instantiate(powerupNameText, cam.WorldToScreenPoint(transform.position), Quaternion.identity, canvas);
            TMP_Text powerupName = powerupNameGameObject.GetComponent<TMP_Text>();
            powerupName.text = randomShot.ToString() + " Shot";
            Destroy(powerupNameGameObject, 1);

            Destroy(gameObject);
        }
    }

}
