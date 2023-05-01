using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDestroyer : MonoBehaviour
{
    [SerializeField] private List<GameObject> thingsToDestroy = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        foreach (GameObject gameObject in thingsToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
