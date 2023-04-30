using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] private Vector2 scrollAmount;

    private Transform _cam;
    private Vector3 _lastCamPos;

    // Start is called before the first frame update
    private void Start()
    {
        _cam = Camera.main.transform;
        _lastCamPos = _cam.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camDistMoved = _cam.position - _lastCamPos;
        transform.position += new Vector3(camDistMoved.x * scrollAmount.x, camDistMoved.y * scrollAmount.y, 0);
        _lastCamPos = _cam.position;
    }
}
