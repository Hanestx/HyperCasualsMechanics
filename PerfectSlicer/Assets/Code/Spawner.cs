using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FruitSlicer
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _templates;
        [SerializeField] private float _spawnDelay;


        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                int foodNumber = Random.Range(0, _templates.Length);
                GameObject food = Instantiate(_templates[foodNumber], transform.position, _templates[foodNumber].transform.rotation);
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}