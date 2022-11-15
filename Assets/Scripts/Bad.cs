using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad : MonoBehaviour
{

    public float speed = 5;

    Effects effects;
    ObjectShake cameraShake;
    AudioManager audioManager;
    Player player;
    Rigidbody2D badBody;
    Camera cam;

    void Start() {

        audioManager = GameObject.Find("Game Controller").GetComponent<AudioManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
        effects = Camera.main.GetComponent<Effects>();
        cameraShake = Camera.main.GetComponent<ObjectShake>();
        badBody = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        badBody.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Bullet")) {
            Destroy(gameObject);
            audioManager.PlaySound(audioManager.destroy);
            player.AddKill(-50, false);
            effects.PauseForEffect(0.3f);
            cameraShake.Shake(0.2f, 0.5f);
            cam.backgroundColor = Color.black;
        }
    }

}
