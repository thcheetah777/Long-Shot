using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float points = 10;
    public float spawnSpeedChange = 0.01f;
    public bool colliderDelay = true;

    Effects effects;
    ObjectShake cameraShake;
    AudioManager audioManager;
    Player player;
    Spawner enemySpawner;
    Collider2D enemyCollider;

    void Start() {
        audioManager = GameObject.Find("Game Controller").GetComponent<AudioManager>();
        enemySpawner = GameObject.Find("Game Controller").GetComponent<Spawner>();
        player = GameObject.Find("Player").GetComponent<Player>();
        effects = Camera.main.GetComponent<Effects>();
        cameraShake = Camera.main.GetComponent<ObjectShake>();
        enemyCollider = GetComponent<Collider2D>();
        enemyCollider.enabled = false;
        if (colliderDelay) StartCoroutine(EnableCollider());
        else enemyCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Bullet")) {
            Destroy(gameObject);
            if (enemySpawner.spawnMultiplier > 0) enemySpawner.spawnMultiplier -= spawnSpeedChange;
            audioManager.PlaySound(audioManager.destroy);
            player.AddKill(points * collider.GetComponent<Bullet>().combo);
            effects.PauseForEffect(0.15f);
            cameraShake.Shake(0.1f, 0.2f);
        }
    }

    private IEnumerator EnableCollider() {
        yield return new WaitForSeconds(0.5f);
        enemyCollider.enabled = true;
    }

}
