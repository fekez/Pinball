using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Collider2D _slider;
    private float _horizontalAxis;
    private float _horizontalLimit;
    private Vector3 _cameraPosition;
    private Collider2D _wall;

    private void Awake()
    {
        _wall = GameObject.Find("wall").GetComponent<Collider2D>();
        _slider = GetComponent<Collider2D>();
        _horizontalLimit = Camera.main.aspect * Camera.main.orthographicSize - _slider.bounds.size.x / 2f - _wall.bounds.size.x / 2;
        _cameraPosition = Camera.main.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");

        if (Mathf.Abs(transform.position.x) < _horizontalLimit + _cameraPosition.x || 
            Mathf.Sign(_horizontalAxis) != Mathf.Sign(transform.position.x))
        {
            transform.Translate(new Vector3(_horizontalAxis * _speed * Time.deltaTime, 0, 0));
        }


    }
}
