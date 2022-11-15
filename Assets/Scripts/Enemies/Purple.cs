using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour
{
    
    public float speed = 0.1f;
    public float shootForce = 10;
    public float shootDelay = 1;
    public GameObject bulletPrefab;

    Rigidbody2D enemyBody;

    void Start() {
        enemyBody = GetComponent<Rigidbody2D>();

        enemyBody.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);

        StartCoroutine(ShootBulletLoop(shootDelay));

        Destroy(gameObject, 50);
    }

    void Update() {
        enemyBody.MoveRotation(enemyBody.rotation + 1);
    }

    private IEnumerator ShootBulletLoop(float delay) {
        while (true)
        {
            yield return new WaitForSecondsRealtime(delay);
            ShootBullet();
        }
    }

    private void ShootBullet() {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddRelativeForce(Vector2.up * shootForce, ForceMode2D.Impulse);
    }

}
