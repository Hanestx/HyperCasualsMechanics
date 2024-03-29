﻿using UnityEngine;


namespace SnakeVsBlock
{
    public class CameraResolution : MonoBehaviour
    {
        private float _defaultWidth;
        private Camera _camera;

        
        private void Start()
        {
            _camera = Camera.main;
            _defaultWidth = _camera.orthographicSize * _camera.aspect;
        }

        private void Update()
        {
            _camera.orthographicSize = _defaultWidth / _camera.aspect;
        }
    }
}