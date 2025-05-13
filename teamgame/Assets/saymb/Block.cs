using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockID; // ブロックの識別用ID
    public Color blockColor; // ブロックの色
    public bool isActive; // ブロックの状態

    public BlockData blockData;

    void Start()
    {

        // データに基づいて初期化
        GetComponent<Renderer>().material.color = blockData.blockColor;
        gameObject.SetActive(blockData.isActive);
    }

    public void DeactivateBlock()
    {
        isActive = false;
        gameObject.SetActive(false); // ブロックを非表示にする
    }

    public void ActivateBlock()
    {
        isActive = true;
        gameObject.SetActive(true); // ブロックを再表示する
    }
}


