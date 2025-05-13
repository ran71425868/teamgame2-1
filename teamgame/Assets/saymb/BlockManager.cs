using System.Collections.Generic;
using UnityEngine;

public class BlockManager : SingletonMonoBehaviour<BlockManager>
{
    public List<Block> blocks = new List<Block>(); // ブロックのリスト

    void Start()
    {

    }

    public Block GetBlockByID(int id)
    {
        // シーン内のすべてのブロックを取得
        Block[] allBlocks = FindObjectsOfType<Block>();
        blocks.AddRange(allBlocks);

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
