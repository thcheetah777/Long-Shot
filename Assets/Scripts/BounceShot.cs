using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShot : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision) {
        GetComponent<Collider2D>().isTrigger = true;
        Destroy(gameObject, 5);
    }

}
