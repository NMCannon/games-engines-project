using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Print hit object's name
        print("hit " + other.name + "!");
        // Destory the bullet
        Destroy(gameObject);
    }
}
