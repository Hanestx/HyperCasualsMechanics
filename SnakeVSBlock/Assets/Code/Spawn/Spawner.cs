﻿using UnityEngine;


namespace SnakeVsBlock.Spawn
{
    public class Spawner : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private Transform _container;
        [SerializeField] private int _repeatCount;
        [SerializeField] private float _distanceBetweenFullLine;
        [SerializeField] private float _distanceBetweenRandomLine;
        
        [Header("Block")]
        [SerializeField] private Block _blockTemplate;
        [SerializeField] private int _blockSpawnChance;
        
        [Header("Wall")]
        [SerializeField] private Wall _wallTemplate;
        [SerializeField] private int _wallSpawnChance;
        
        private BlockSpawnPoint[] _blockSpawnPoints;
        private WallSpawnPoint[] _wallSpawnPoints;


        private void Start()
        {
            _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
            _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();

            for (int i = 0; i < _repeatCount; i++)
            {
                MoveSpawner(_distanceBetweenFullLine);
                GenerateRandomElements(_wallSpawnPoints,  _wallTemplate.gameObject, _wallSpawnChance, _distanceBetweenFullLine,_distanceBetweenFullLine / 2.0f);
                GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);
                MoveSpawner(_distanceBetweenRandomLine);
                GenerateRandomElements(_wallSpawnPoints,  _wallTemplate.gameObject, _wallSpawnChance, _distanceBetweenRandomLine, _distanceBetweenRandomLine / 2.0f);
                GenerateRandomElements(_blockSpawnPoints,  _blockTemplate.gameObject, _blockSpawnChance);
            }
        }

        
        private void MoveSpawner(float distanceY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
        }

        private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GenerateElement(spawnPoints[i].transform.position, generatedElement);
            }
        }

        private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance, float scaleY = 0.15f, float offsetY = 0)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (Random.Range(0,100) < spawnChance)
                {
                    GameObject element = GenerateElement(spawnPoints[i].transform.position, generatedElement);
                    element.transform.localScale = new Vector3(element.transform.localScale.x, scaleY, element.transform.localScale.z);
                }
            }
        }

        private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement, float offsetY = 0)
        {
            spawnPoint.y -= offsetY;
            return Instantiate(generatedElement, spawnPoint, Quaternion.identity, _container);
        }
    }
}