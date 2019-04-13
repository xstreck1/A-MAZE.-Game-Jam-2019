using UnityEngine;
using System.Collections.Generic;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Block> _blockPrefabs;

    private float _combinedWeight = 0f;

    private void Start()
    {
        foreach (var t in _blockPrefabs)
        {
            _combinedWeight += t.Weight;
        }

        foreach (var t in _blockPrefabs)
        {
            t.Weight = t.Weight / _combinedWeight;
        }
    }

    public Block GetNewBlock()
    {
        float random = Random.Range(0f, 1f);
        float weightSum = 0f;
        Block blockPrefab = null;

        foreach (var t in _blockPrefabs)
        {
            weightSum += t.Weight;
            
            if (random <= weightSum)
            {
                blockPrefab = t.GetComponent<Block>();
                break;
            }
        }

        if (blockPrefab == null)
        {
            blockPrefab = _blockPrefabs[_blockPrefabs.Count - 1];
        }

        // Spawn outside of existing block
        var newBlock = Instantiate(blockPrefab, Vector3.up * 1000f, Quaternion.identity);

        return newBlock;
    }
}