using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// メニューシーンが起動したらここから
/// </summary>
public class MenuSceneController : MonoBehaviour
{
    // 必要なオブジェクトを取り付けていく
    [SerializeField]
    private List<UIToolSelectCell> toolSelectCells;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var cell in toolSelectCells)
        {
            cell.SetButtonClickCallback(OnClickedToolSelectCell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ツールセレクトセルが押された際の処理
    private void OnClickedToolSelectCell(EToolType toolType) {

        switch (toolType) { 
            case EToolType.None:

                break;

            case EToolType.Ship:

                break;


        }
    }
}
