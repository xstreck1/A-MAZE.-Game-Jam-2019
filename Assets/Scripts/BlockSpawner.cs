using UnityEngine;
using System.Collections.Generic;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Block> _blockPrefabs;

    private float _combinedWeight = 0f;

    private void Start()
    {
        for (int i = 0; i < _blockPrefabs.Count; ++i)
        {
            _combinedWeight += _blockPrefabs[i].Weight;
        }

        for (int i = 0; i < _blockPrefabs.Count; ++i)
        {
            _blockPrefabs[i].Weight = _blockPrefabs[i].Weight / _combinedWeight;
        }
    }

    public Block GetNewBlock()
    {
        float random = Random.Range(0f, 1f);
        float weightSum = 0f;
        Block blockPrefab = null;

        for (int i = 0; i < _blockPrefabs.Count; ++i)
        {
            weightSum += _blockPrefabs[i].Weight;
            if (random > weightSum)
            {
                blockPrefab = _blockPrefabs[i].GetComponent<Block>();
                break;
            }
        }

        if (blockPrefab == null)
        {
            blockPrefab = _blockPrefabs[_blockPrefabs.Count - 1];
        }

        var newBlock = Instantiate(blockPrefab);

        return newBlock;
    }
}