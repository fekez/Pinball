using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    [SerializeField] private GameObject _clone;
    [SerializeField] private GameObject _wall;
    private float _cameraWidth;
    private float _cameraHeight;
    private Vector3 _cameraPosition;

    private void Awake()
    {
        _cameraHeight = Camera.main.orthographicSize;
        _cameraWidth = Camera.main.aspect * _cameraHeight;
        _cameraPosition = Camera.main.transform.position;

        GameObject rightWallClone = GameObject.Instantiate(_wall);
        rightWallClone.transform.position = new Vector3(_cameraPosition.x + -_cameraWidth, _cameraPosition.y, 0);

        GameObject leftWallClone = GameObject.Instantiate(_wall);
        leftWallClone.transform.position = new Vector3(_cameraPosition.x + _cameraWidth, _cameraPosition.y, 0);

        GameObject ceilingClone = GameObject.Instantiate(_wall);
        ceilingClone.transform.localScale = new Vector3(4f, ceilingClone.transform.localScale.y, ceilingClone.transform.localScale.z);
        ceilingClone.transform.Rotate(new Vector3(0, 0, 90));
        ceilingClone.transform.position = new Vector3(_cameraPosition.x, _cameraPosition.y + _cameraHeight, 0);

        bool even = false;
        for (float i = _cameraHeight + _cameraPosition.y - 1f; i >= -_cameraHeight + _cameraPosition.y + 3f; i -= 0.3f)
        {
            for (float j = (even ? -_cameraWidth + _cameraPosition.x + 3f: -_cameraWidth + _cameraPosition.x + 3.5f); j <= _cameraWidth + _cameraPosition.x - 3f; j++)
            {
                GameObject cloneMaker = GameObject.Instantiate(_clone);
                cloneMaker.transform.position = new Vector3(j, i, 0);
            }
            even = !even;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
