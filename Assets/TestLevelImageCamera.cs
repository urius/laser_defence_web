using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelImageCamera : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        //_camera.Render();
    }

    // Update is called once per frame
    void Update()
    {
        _camera.Render();
        gameObject.SetActive(false);
    }
}
