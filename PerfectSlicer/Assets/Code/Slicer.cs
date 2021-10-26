using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicerSamples;


namespace FruitSlicer
{
    public class Slicer : MonoBehaviour
    {
        [SerializeField] private GameObject _blade;
        [SerializeField] private float _duration;
        [SerializeField] private float _offsetY;

        private BzKnife _knife;


        private void Start()
        {
            _knife = _blade.GetComponentInChildren<BzKnife>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _knife.BeginNewSlice();
                _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration / 2.0f).SetLoops(2, LoopType.Yoyo);
            }
        }
    }
}