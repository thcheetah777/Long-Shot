using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ShotType
{
    Long,
    Triple,
    Bounce,
    Homing
}

public class Player : MonoBehaviour
{

    public float moveSpeed = 15;
    public float shootForce = 30;
    public float trailIncrement = 0.05f;
    public float slowmoTime = 0.3f;
    public float tripleShotMargin = 10;
    public GameObject bulletPrefab;
    public GameObject smallBulletPrefab;
    public GameObject bounceBulletPrefab;
    public GameObject homingBulletPrefab;
    public ShotType shotType = ShotType.Long;

    public int kills = 0;
    public float points = 0;

    public TMP_Text scoreText;
    
    private Color backgroundColor;

    [SerializeField] Transform arrow;
    [SerializeField] Transform arrowAnchor;
    [SerializeField] TrailRenderer playerTrail;
    [SerializeField] AudioSource backgroundMusicSource;

    Rigidbody2D playerBody;
    AudioManager audioManager;
    Camera cam;

    void Start() {
        cam = Camera.main;
        backgroundColor = cam.backgroundColor;
        audioManager = GameObject.Find("Game Controller").GetComponent<AudioManager>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, backgroundColor, 0.05f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = slowmoTime;
            Time.fixedDeltaTime = slowmoTime * 0.02f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            backgroundMusicSource.pitch = Mathf.Lerp(backgroundMusicSource.pitch, 0.5f, 0.05f);
        } else
        {
            backgroundMusicSource.pitch = Mathf.Lerp(backgroundMusicSource.pitch, 1, 0.05f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            audioManager.PlaySound(audioManager.shoot);

            playerBody.velocity = (arrow.position - transform.position).normalized * moveSpeed;

            if (shotType == ShotType.Long)
            {
                shootForce = 30;
                GameObject bullet = Instantiate(bulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            } else if (shotType == ShotType.Triple) {
                shootForce = 30;
                for (int i = -1; i < 2; i++)
                {
                    Quaternion rotation = arrowAnchor.rotation * Quaternion.Euler(0, 0, i * tripleShotMargin);
                    GameObject bullet = Instantiate(smallBulletPrefab, arrow.position, rotation);
                    Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                    bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
                }
            } else if (shotType == ShotType.Bounce) {
                shootForce = 15;
                GameObject bullet = Instantiate(bounceBulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            } else if (shotType == ShotType.Homing) {
                shootForce = 10;
                GameObject bullet = Instantiate(homingBulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            }
        }
    }

    public void Die() {
        SceneLoader.DieScene();
    }

    public void AddKill(float pointsIncrement, bool trailAdd = true) {
        kills++;
        points += pointsIncrement;
        if (trailAdd) playerTrail.time += trailIncrement;
        scoreText.text = points.ToString();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Enemy Trail")) Die();
    }

}
