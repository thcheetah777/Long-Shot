using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemyTrail : MonoBehaviour
{

    public GameObject trailCollider;

    TrailRenderer trailRenderer;

    void Start() {
        trailRenderer = GetComponent<TrailRenderer>();
        StartCoroutine(CollisionSpawner());
    }

    private IEnumerator CollisionSpawner() {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject collider = Instantiate(trailCollider, transform.position, Quaternion.identity);
            transform.parent.GetComponent<Pink>().trailColliders.Add(collider);
            Destroy(collider, trailRenderer.time);
        }
    }

}
