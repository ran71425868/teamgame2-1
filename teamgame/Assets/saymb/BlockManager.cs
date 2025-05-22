using System.Collections.Generic;
using UnityEngine;

public class BlockManager : SingletonMonoBehaviour<BlockManager>
{
    public List<MoveBlock> blocks = new List<MoveBlock>(); // ブロックのリスト

    void Start()
    {
        
    }

    public MoveBlock GetBlockByNum(int num)
    {
        // シーン内のすべてのブロックを取得
        //Block[] allBlocks = FindObjectsOfType<Block>();
        //blocks.AddRange(allBlocks);



        if (blocks.Count > 0)
        {
            blocks.RemoveAt(0);
        }

        // IDでブロックを検索
        return this.blocks[num];

       
        //return this.blocks.Find(block => block.blockID == id);
    }

    //public void DeactivateAllBlocks()
    //{
    //    foreach (MoveBlock block in blocks)
    //    {
    //        block.DeactivateBlock();
    //    }
    //}
}
