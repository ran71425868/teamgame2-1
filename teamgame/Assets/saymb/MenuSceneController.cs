using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// メニューシーンが起動したらここから
/// </summary>
public class MenuSceneController : MonoBehaviour
{
    // 必要なオブジェクトを取り付けていく
    [SerializeField]
    private List<UIToolSelectCell> toolSelectCells;

    [SerializeField] private int BlockNumber = 0;
    [SerializeField] extern public MoveBlock MovementControll();

    [SerializeField] private GameObject noneObj = null;
    [SerializeField] private GameObject noneParent = null;

    [SerializeField] private GameObject shipObj=null;
    [SerializeField] private GameObject shipParent=null;


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

    /// <summary>
    /// ボタンリセット
    /// </summary>
    public void ResetButton()
    {
        foreach (var cell in toolSelectCells)
        {
            cell.ResetButtonInteractable();
        }

        for(int i = 0; i > this.toolSelectCells.Count; i++)
        {
            toolSelectCells[i].ResetButtonInteractable();
        }
    }

    // ツールセレクトセルが押された際の処理
    private void OnClickedToolSelectCell(EToolType toolType) {

        switch (toolType)
        {
            case EToolType.None:
                BlockNumber = 1;
                

                GameObject instanceObjNone = GameObject.Instantiate(this.noneObj, this.noneParent.transform);
                instanceObjNone.transform.position = Vector3.zero;

                SceneManager.LoadScene("Smap", LoadSceneMode.Additive);

                if (BlockNumber == 1)
                {
                    MovementControll();
                    BlockNumber = 0;
                }
                break;

            case EToolType.Ship:

                BlockNumber = 2;
                
                //Debug.Log($"きた {toolType}");
                GameObject instanceObjShip = GameObject.Instantiate(this.shipObj, this.shipParent.transform);
                instanceObjShip.transform.position = Vector3.zero;

                SceneManager.LoadScene("Smap", LoadSceneMode.Additive);

                if (BlockNumber == 2)
                {
                    MovementControll();
                    BlockNumber = 0;
                }

                break; 


        }
    }
}
