using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _blockPrefabs;

    private List<GameObject> _spawnedBlocks = new List<GameObject>();

    //private float _currentHeight = 0f;

    private float CurrentHeight { get; } = 0f;

    public GameObject GetNewBlock()
    {
        GameObject newBlock = new GameObject();

        if (_blockPrefabs == null || _blockPrefabs.Count == 0)
        {
            Debug.Log("No block prefabs found");
            return newBlock;
        }

        int random = Random.Range(0, _blockPrefabs.Count);

        Instantiate(_blockPrefabs[random]);

        return newBlock;
    }
}