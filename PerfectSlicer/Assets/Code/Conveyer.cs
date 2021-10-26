using UnityEngine;


namespace FruitSlicer
{
    public class Conveyer : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _speed;


        private void OnTriggerStay(Collider other)
        {
            other.transform.position =
                Vector3.MoveTowards(other.transform.position, _endPoint.position, _speed * Time.deltaTime);
        }
    }
}