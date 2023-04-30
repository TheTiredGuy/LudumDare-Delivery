using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwapper : MonoBehaviour
{

    [SerializeField] private Sprite carriage;
    [SerializeField] private Vector2 sizeOfCollider = new Vector2(8f, 2f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (other.TryGetComponent(out Animator anim))
        {
            anim.SetBool("isCarriage", true);
        }

        if (other.TryGetComponent(out SpriteRenderer sprite))
        {
            sprite.sprite = carriage;
        }

        if (other.TryGetComponent(out BoxCollider2D collider))
        {
            collider.size = sizeOfCollider;
        }
    }
}
