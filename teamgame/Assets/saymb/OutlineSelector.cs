using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OutlineToggle : MonoBehaviour
{
    public Material outlineMaterial;
    private GameObject outlineObject;

    void Start()
    {
        // アウトライン用のオブジェクト作成
        outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        DestroyImmediate(outlineObject.GetComponent<OutlineToggle>()); // 自身のスクリプトは削除
       outlineObject.transform.localScale = outlineObject.transform.localScale * 0.01f;
        outlineObject.GetComponent<Renderer>().material = outlineMaterial;
    }

    void Update()
    {
        //if (IsSelected())
        //{
            outlineObject.SetActive(true);
        //}
        //else
        //{
        //    outlineObject.SetActive(false);
        //}
    }

    // ★ 選択判定（ここは好みに応じて修正）
    //bool IsSelected()
    //{
    //    // 例：マウスオーバー or クリックされたとき
    //    return Input.GetMouseButton(0); // 仮：クリック時にアウトライン表示
    //}
}
