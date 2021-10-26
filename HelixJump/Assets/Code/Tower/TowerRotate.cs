using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotationSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);
                
            }
        }
    }
}
