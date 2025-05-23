using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// メニューシーンが起動したらここから
/// </summary>
public class MenuSceneController : MonoBehaviour
{
    // 必要なオブジェクトを取り付けていく
    [SerializeField]
    private List<UIToolSelectCell> toolSelectCells;

    //[SerializeField] extern public MoveBlock MovementControll();

    [SerializeField] private GameObject scaffoldObj = null;
    [SerializeField] private GameObject scaffoldParent = null;

    [SerializeField] private GameObject shipObj=null;
    [SerializeField] private GameObject shipParent=null;

    [SerializeField] private GameObject starObj = null;
    [SerializeField] private GameObject starParent = null;


    // int[] hairetu = new int[4] { 1, 2, 3, 4 };


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

        //for(int i = 0; i > this.toolSelectCells.Count; i++)
        //{
        //    toolSelectCells[i].ResetButtonInteractable();
        //}
    }

    // ツールセレクトセルが押された際の処理
    private void OnClickedToolSelectCell(EToolType toolType) {

        switch (toolType)
        {
            case EToolType.Scaffold:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.scaffoldObj, this.scaffoldParent.transform);
                    var block = instanceObj.GetComponent<MoveBlock>();
                    // 作成したブロックを動かせるようにフラグを立てておく
                    block.focusFlag = true;
                    BlockManager.Instance.Add(block);

                    instanceObj.transform.position = Vector3.one;

                    if (!SceneManager.GetSceneByName("Smap").IsValid())
                    {
                        Debug.Log("Smapシーンないので生成する");
                        SceneManager.LoadScene("Smap", LoadSceneMode.Additive);
                    }
                    var getBlock = BlockManager.Instance.GetBlockByNum(0);
                }

                break;

            case EToolType.Ship:

                {
                    GameObject instanceObj = GameObject.Instantiate(this.shipObj, this.shipParent.transform);
                    var block = instanceObj.GetComponent<MoveBlock>();

                    // 作成したブロックを動かせるようにフラグを立てておく
                    block.focusFlag = true;
                    BlockManager.Instance.Add(block);

                    instanceObj.transform.position = Vector3.one;

                    if (!SceneManager.GetSceneByName("Smap").IsValid())
                    {
                        Debug.Log("Smapシーンないので生成する");
                        SceneManager.LoadScene("Smap", LoadSceneMode.Additive);
                    }

                    var getBlock = BlockManager.Instance.GetBlockByNum(1);
                }
                
                break;

            case EToolType.Star:
                {
                    GameObject instanceObj = GameObject.Instantiate(this.starObj, this.starParent.transform);
                    var block = instanceObj.GetComponent<MoveBlock>();

                    // 作成したブロックを動かせるようにフラグを立てておく
                    block.focusFlag = true;
                    BlockManager.Instance.Add(block);

                    instanceObj.transform.position = Vector3.one;

                    if (!SceneManager.GetSceneByName("Smap").IsValid())
                    {
                        Debug.Log("Smapシーンないので生成する");
                        SceneManager.LoadScene("Smap", LoadSceneMode.Additive);
                    }

                    var getBlock = BlockManager.Instance.GetBlockByNum(2);
                }

                //ResetButton();

                break;

            case EToolType.Back:
                {
                    var block = BlockManager.Instance.Removed();

                    Destroy(block.gameObject);
                }
               
                break;

        }
    }
}
