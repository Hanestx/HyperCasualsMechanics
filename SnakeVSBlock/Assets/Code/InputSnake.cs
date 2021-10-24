using System;
using UnityEngine;

namespace SnakeVsBlock
{
    public class InputSnake : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        public Vector2 GetDirectionToCLick(Vector2 headPosition)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = _camera.ScreenToViewportPoint(mousePosition);
            mousePosition.y = 1;
            mousePosition = _camera.ViewportToWorldPoint(mousePosition);
            
            Vector2 direction = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);

            return direction;
        }
    }
}