using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        if (player.TryGetComponent(out Health health))
        {
            health.Damage();
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        if (player.TryGetComponent(out Health health))
        {
            health.Damage();
        }

    }

}
