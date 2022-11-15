using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShot : MonoBehaviour
{

    public GameObject targetEnemy;

    Rigidbody2D shotBody;

    void Start() {
        shotBody = GetComponent<Rigidbody2D>();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float nearest = float.PositiveInfinity;
        GameObject nearestEnemy = null;
        
        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(enemy.transform.position, transform.position);
            if (distance < nearest)
            {
                nearest = distance;
                nearestEnemy = enemy;
            }
        }

        targetEnemy = nearestEnemy;
    }

    void FixedUpdate() {
        if (targetEnemy)
        {
            shotBody.position = Vector2.Lerp(shotBody.position, targetEnemy.transform.position, 0.3f);
        }
    }

}
