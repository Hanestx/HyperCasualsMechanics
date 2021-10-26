using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _shaft;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private float _startAndFinishAdditionalScale =  0.5f;
    public float shaftScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject shaft = Instantiate(_shaft, transform);
        shaft.transform.localScale = new Vector3(1,shaftScaleY,1);

        Vector3 spawnPosition = shaft.transform.position;
        spawnPosition.y += shaft.transform.localScale.y - _additionalScale;
        
        SpawnPlatform(_startPlatform, ref spawnPosition, shaft.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, shaft.transform);
        }
        
        SpawnPlatform(_finishPlatform, ref spawnPosition, shaft.transform);

    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition,Transform parent)
    {
        Instantiate(platform, spawnPosition,Quaternion.Euler(0,Random.Range(0, 360),0), parent);
        spawnPosition.y -= 1;
    }
}
