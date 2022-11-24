using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int combo = 0;
    public bool autodestroy = true;
    public float trailSizeIncrement = 0.3f;
    public float trailLengthIncrement = 0.1f;
    [SerializeField] TrailRenderer bulletTrail;

    ObjectShake scoreTextShake;

    void Start() {
        scoreTextShake = GameObject.Find("Score Text").GetComponent<ObjectShake>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Border") && autodestroy) Destroy(gameObject, 0.5f);
        if (collider.CompareTag("Enemy"))
        {
            combo++;

            if (combo == 2)
            {
                scoreTextShake.Shake(0.2f, 8);
            } else if (combo == 3) {
                scoreTextShake.Shake(0.5f, 10);
            } else if (combo == 4) {
                scoreTextShake.Shake(0.5f, 15);
            } else if (combo == 5) {
                scoreTextShake.Shake(0.5f, 20f);
            } else if (combo >= 6) {
                scoreTextShake.Shake(0.5f, 30f);
            }

            bulletTrail.startWidth = bulletTrail.startWidth + trailSizeIncrement;
        }
    }

}
