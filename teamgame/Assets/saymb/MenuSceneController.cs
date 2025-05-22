using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    //[SerializeField] extern public MoveBlock MovementControll();

    [SerializeField] private GameObject noneObj = null;
    [SerializeField] private GameObject noneParent = null;

    [SerializeField] private GameObject shipObj=null;
    [SerializeField] private GameObject shipParent=null;

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
            case EToolType.None:
            

                GameObject instanceObj = GameObject.Instantiate(this.noneObj, this.noneParent.transform);
                var block = instanceObj.GetComponent<MoveBlock>();
                BlockManager.Instance.blocks.Add(block);
                instanceObj.transform.position = Vector3.one;

                if (!SceneManager.GetSceneByName("Smap").IsValid())
                {
                    Debug.Log("Smapシーンないので生成する");
                    SceneManager.LoadScene("Smap", LoadSceneMode.Additive);
                }
                var getBlock =  BlockManager.Instance.GetBlockByNum(0);


               
                //BlockManager.Instance.blocks.RemoveAt(1);
                //BlockManager.Instance.blocks.Remove(block);


                break;

            case EToolType.Ship:


                instanceObj = GameObject.Instantiate(this.shipObj, this.shipParent.transform);
                block = instanceObj.GetComponent<MoveBlock>();
                BlockManager.Instance.blocks.Add(block);
                instanceObj.transform.position = Vector3.one;

                if (!SceneManager.GetSceneByName("Smap").IsValid())
                {
                    Debug.Log("Smapシーンないので生成する");
                    SceneManager.LoadScene("Smap", LoadSceneMode.Additive);
                }

                getBlock = BlockManager.Instance.GetBlockByNum(1);

                //if (BlockManager.Instance.blocks.Count == 2)
                //{
                //    instanceObj.SetActive(false);
                //}

                //BlockManager.Instance.blocks.RemoveAt(1);


                break;

            case EToolType.Reset:

                ResetButton();

                break;


            case EToolType.back:

                //BlockManager.Instance.blocks.RemoveAt(1);
                //BlockManager.Instance.blocks.Remove(block);
                break;

        }
    }
}
