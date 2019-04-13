using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _blockPrefabs;

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