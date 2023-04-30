using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float _knockbackPower = 500f;
    [SerializeField] private int _healthPoints = 3;
    [SerializeField] private float invincibilityTime = 3f;
    [SerializeField] private GameObject ouchBox;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool damageable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent <SpriteRenderer>();
        ouchBox.SetActive(false);
        damageable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_healthPoints <= 0)
        {
            _healthPoints = 0;
            SceneManager.LoadScene("MainScene");
        }
    }

    public void Damage()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * _knockbackPower);
        if (!damageable) return;
        Debug.Log("damaged");
        StartCoroutine(InvincibilityFrames());

    }

    IEnumerator InvincibilityFrames()
    {
        damageable = false;
        sr.color = Color.red;
        ouchBox.SetActive(true);
        _healthPoints--;
        
        yield return new WaitForSeconds(invincibilityTime);
        sr.color = Color.white;
        ouchBox.SetActive(false);
        damageable = true;
    }

}
