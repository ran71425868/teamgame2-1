using System.Collections.Generic;
using UnityEngine;

public class BlockManager : SingletonMonoBehaviour<BlockManager>
{
    private List<MoveBlock> blocks = new List<MoveBlock>(); // ブロックのリスト

    void Start()
    {
        
    }

    public MoveBlock GetBlockByNum(int num)
    {
        // シーン内のすべてのブロックを取得
        //Block[] allBlocks = FindObjectsOfType<Block>();
        //blocks.AddRange(allBlocks);


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

    public void Add(MoveBlock block) {

        // 現在取り付けられている奴らの動かせるフラグを全て下ろす
        foreach (var b in blocks) { 
            b.focusFlag = false;
        }

        blocks.Add(block);
    }

    /// <summary>
    /// 一番下を取り外す
    /// 取り外したブロックを戻り値として受け取る
    /// </summary>
    /// <returns></returns>
    public MoveBlock Removed()
    {
        MoveBlock block = blocks[blocks.Count - 1];

        // 一番下を外す
        int count = blocks.Count;
        blocks.RemoveAt(count - 1);


        // 一番下が存在したら
        //if (block.selectNumber == select)
        //{
        //    if (blocks.Count > 0)
        //    {
        //        blocks[blocks.Count - 1].focusFlag = true;
        //    }
        //}

        return block;
    }

    public int GetListCount()
    {
        return blocks.Count;
    }
}
