using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{

    [SerializeField] private GameObject _dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _dialogue.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _dialogue.SetActive(false);
    }
}
