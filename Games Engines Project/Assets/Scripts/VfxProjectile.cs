using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxProjectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Print hit object's name
        //print("hit " + other.name + "!");

        if (other.name == "fpsPlayer")
        {
            var healthComponent = other.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }
        }
        else if (other.name == "Enemy" || other.name == "Enemy(Clone)")
        {
            var healthComponent = other.GetComponent<EnemyHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }
        }

        // Destory the bullet
        Destroy(gameObject);
    }
}
