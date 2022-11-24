using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public enum ShotType
{
    Long,
    Triple,
    Bounce,
    Squiggle,
    Curve,
    Wide,
    Snake,
    Sniper
}

public class Player : MonoBehaviour
{

    public bool invincible = false;
    public float moveSpeed = 15;
    public float shootForce = 30;
    public float trailIncrement = 0.05f;
    public float slowmoTime = 0.3f;
    public float tripleShotMargin = 10;
    public ShotType shotType = ShotType.Long;
    public UnityEvent onDie;

    public GameObject bulletPrefab;
    public GameObject smallBulletPrefab;
    public GameObject bounceBulletPrefab;
    public GameObject squiggleBulletPrefab;
    public GameObject curveBulletPrefab;
    public GameObject wideBulletPrefab;
    public GameObject snakeBulletPrefab;
    public GameObject sniperBulletPrefab;

    public int kills = 0;

    private Color backgroundColor;

    [SerializeField] Transform arrow;
    [SerializeField] Transform arrowAnchor;
    [SerializeField] TrailRenderer playerTrail;
    [SerializeField] AudioSource backgroundMusicSource;

    Rigidbody2D playerBody;
    AudioManager audioManager;
    PointsManager pointsManager;
    Camera cam;

    void Start() {
        cam = Camera.main;
        backgroundColor = cam.backgroundColor;
        audioManager = GameObject.Find("Game Controller").GetComponent<AudioManager>();
        pointsManager = GameObject.Find("Points Manager").GetComponent<PointsManager>();
        playerBody = GetComponent<Rigidbody2D>();

        pointsManager.ResetPoints();
    }

    void Update() {
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, backgroundColor, 0.05f);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            float slowmoTimeBefore = slowmoTime;
            if (shotType == ShotType.Sniper) slowmoTime = 0.1f;
            else slowmoTime = slowmoTimeBefore;

            Time.timeScale = slowmoTime;
            Time.fixedDeltaTime = slowmoTime * 0.02f;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            backgroundMusicSource.pitch = Mathf.Lerp(backgroundMusicSource.pitch, 0.5f, 0.05f);
        } else
        {
            backgroundMusicSource.pitch = Mathf.Lerp(backgroundMusicSource.pitch, 1, 0.05f);
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            audioManager.PlaySound(audioManager.shoot);

            playerBody.velocity = (arrow.position - transform.position).normalized * moveSpeed;

            if (shotType == ShotType.Triple) {
                shootForce = 40;
                for (int i = -1; i < 2; i++)
                {
                    Quaternion rotation = arrowAnchor.rotation * Quaternion.Euler(0, 0, i * tripleShotMargin);
                    GameObject bullet = Instantiate(smallBulletPrefab, arrow.position, rotation);
                    Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                    bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
                }
            } else if (shotType == ShotType.Bounce) {
                shootForce = 30;
                GameObject bullet = Instantiate(bounceBulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            } else if (shotType == ShotType.Squiggle) {
                Instantiate(squiggleBulletPrefab, arrow.position, arrowAnchor.rotation);
            } else if (shotType == ShotType.Curve) {
                Instantiate(curveBulletPrefab, arrow.position, arrowAnchor.rotation);
            } else if (shotType == ShotType.Wide) {
                shootForce = 25;
                GameObject bullet = Instantiate(wideBulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            } else if (shotType == ShotType.Snake) {
                Instantiate(snakeBulletPrefab, arrow.position, arrowAnchor.rotation);
            } else if (shotType == ShotType.Sniper) {
                shootForce = 80;
                GameObject bullet = Instantiate(sniperBulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            }

            else {
                shootForce = 50;
                GameObject bullet = Instantiate(bulletPrefab, arrow.position, arrowAnchor.rotation);
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            }
        }
    }

    public void Die() {
        if (!invincible) onDie.Invoke();
    }

    public void AddKill(float pointsIncrement, bool trailAdd = true) {
        kills++;
        pointsManager.AddPoint(pointsIncrement);
        if (trailAdd) playerTrail.time += trailIncrement;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Enemy Trail")) Die();
    }

}
