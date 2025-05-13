using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public List<Block> blocks = new List<Block>(); // ブロックのリスト

    void Start()
    {
        // シーン内のすべてのブロックを取得
        Block[] allBlocks = FindObjectsOfType<Block>();
        blocks.AddRange(allBlocks);
    }

    public Block GetBlockByID(int id)
    {
        // IDでブロックを検索
        return blocks.Find(block => block.blockID == id);
    }

    public void DeactivateAllBlocks()
    {
        foreach (Block block in blocks)
        {
            block.DeactivateBlock();
        }
    }
}
