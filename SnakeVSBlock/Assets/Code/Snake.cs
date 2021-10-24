using System;
using System.Collections.Generic;
using UnityEngine;


namespace SnakeVsBlock
{
    [RequireComponent(typeof(TailGenerator))]
    [RequireComponent(typeof(InputSnake))]
    public class Snake : MonoBehaviour
    {
        [SerializeField] private SnakeHead _head;
        [SerializeField] private float _speed;
        [SerializeField] private float _tailSpringness;

        private InputSnake _inputSnake;
        private List<Segment> _tail;
        private TailGenerator _tailGenerator;


        private void Awake()
        {
            _inputSnake = GetComponent<InputSnake>();
            _tailGenerator = GetComponent<TailGenerator>();
            _tail = _tailGenerator.Generate();
        }

        private void FixedUpdate()
        {
            Move(_head.transform.position + _head.transform.up * _speed * Time.fixedDeltaTime);

            _head.transform.up = _inputSnake.GetDirectionToCLick(_head.transform.position);
        }

        private void Move(Vector3 nextPosition)
        {
            Vector3 previousPosition = _head.transform.position;

            foreach (var segment in _tail)
            {
                Vector3 tempPosition = segment.transform.position;
                segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition, _tailSpringness);
                previousPosition = tempPosition; 
            }
            
            _head.Move(nextPosition);
        }
    }
}