using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace SnakeVsBlock
{
    [RequireComponent(typeof(TailGenerator))]
    [RequireComponent(typeof(InputSnake))]
    public class Snake : MonoBehaviour
    {
        [SerializeField] private SnakeHead _head;
        [SerializeField] private float _speed;
        [SerializeField] private float _tailSpringness;
        [SerializeField] private int _tailSize;
        private InputSnake _inputSnake;
        private List<Segment> _tail;
        private TailGenerator _tailGenerator;

        public event UnityAction<int> SizeUpdated;


        private void Awake()
        {
            _inputSnake = GetComponent<InputSnake>();
            _tailGenerator = GetComponent<TailGenerator>();
            _tail = _tailGenerator.Generate(_tailSize);
            SizeUpdated?.Invoke(_tail.Count);
        }

        private void FixedUpdate()
        {
            Move(_head.transform.position + _head.transform.up * _speed * Time.fixedDeltaTime);

            _head.transform.up = _inputSnake.GetDirectionToCLick(_head.transform.position);
        }

        private void OnEnable()
        {
            _head.BlockCollided += OnBlockCollided;
            _head.BonusCollected += OnBonusCollected;
        }

        private void OnDisable()
        {
            _head.BlockCollided -= OnBlockCollided;
            _head.BonusCollected -= OnBonusCollected;
        }

        
        private void Move(Vector3 nextPosition)
        {
            Vector3 previousPosition = _head.transform.position;

            foreach (var segment in _tail)
            {
                Vector3 tempPosition = segment.transform.position;
                segment.transform.position =
                    Vector2.Lerp(segment.transform.position, previousPosition, _tailSpringness);
                previousPosition = tempPosition;
            }
            _head.Move(nextPosition);
        }
        
        private void OnBlockCollided()
        {
            Segment deletedSegment = _tail[_tail.Count - 1];
            _tail.Remove(deletedSegment);
            Destroy(deletedSegment.gameObject);
            SizeUpdated?.Invoke(_tail.Count);
        }
        
        private void OnBonusCollected(int bonusSize)
        {
            _tail.AddRange(_tailGenerator.Generate(bonusSize));
            SizeUpdated?.Invoke(_tail.Count);
        }
    }
}