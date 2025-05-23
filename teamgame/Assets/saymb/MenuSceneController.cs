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

    [SerializeField] private GameObject beakObj = null;
    [SerializeField] private GameObject beakParent = null;

    [SerializeField] private GameObject traingularFusionObj = null;
    [SerializeField] private GameObject traingularFusionParent = null;

    [SerializeField] private GameObject rocketObj = null;
    [SerializeField] private GameObject rocketParent = null;

    [SerializeField] private GameObject beatenUpObj = null;
    [SerializeField] private GameObject beatenUpParent = null;

    [SerializeField] private GameObject pigeonObj = null;
    [SerializeField] private GameObject pigeonParent = null;

    [SerializeField] private GameObject triangleObj = null;
    [SerializeField] private GameObject triangleParent = null;

    [SerializeField] private GameObject snakeObj = null;
    [SerializeField] private GameObject snakeParent = null;

    [SerializeField] private GameObject slopeObj = null;
    [SerializeField] private GameObject slopeParent = null;

    [SerializeField] private GameObject screwObj = null;
    [SerializeField] private GameObject screwParent = null;

    [SerializeField] private GameObject sasukeObj = null;
    [SerializeField] private GameObject sasukeParent = null;

    [SerializeField] private GameObject outletObj = null;
    [SerializeField] private GameObject outletParent = null;

    [SerializeField] private GameObject escargotObj = null;
    [SerializeField] private GameObject escargotParent = null;

    [SerializeField] private GameObject curveObj = null;
    [SerializeField] private GameObject curveParent = null;

    [SerializeField] private GameObject clayObj = null;
    [SerializeField] private GameObject clayParent = null;


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

                break;

            case EToolType.Beak:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.beakObj, this.beakParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(3);
                }

                break;

            case EToolType.TriangularFusion:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.traingularFusionObj, this.traingularFusionParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(4);
                }

                break;

            case EToolType.Rocket:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.rocketObj, this.rocketParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(5);
                }

                break;

            case EToolType.BeatenUp:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.beatenUpObj, this.beatenUpParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(6);
                }

                break;

            case EToolType.Pigeon:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.pigeonObj, this.pigeonParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(7);
                }

                break;

            case EToolType.Triangle:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.triangleObj, this.triangleParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(8);
                }

                break;

            case EToolType.Snake:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.snakeObj, this.snakeParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(9);
                }

                break;

            case EToolType.Slope:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.slopeObj, this.slopeParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(10);
                }

                break;

            case EToolType.Screw:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.screwObj, this.screwParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(11);
                }

                break;

            case EToolType.Sasuke:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.sasukeObj, this.sasukeParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(12);
                }

                break;

            case EToolType.Outlet:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.outletObj, this.outletParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(13);
                }

                break;

            case EToolType.Escargot:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.escargotObj, this.escargotParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(14);
                }

                break;

            case EToolType.Curve:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.curveObj, this.curveParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(15);
                }

                break;
            case EToolType.Clay:
                {
                    // ブロックを作成する
                    GameObject instanceObj = GameObject.Instantiate(this.clayObj, this.clayParent.transform);
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
                    var getBlock = BlockManager.Instance.GetBlockByNum(16);
                }

                break;

            case EToolType.Reset:
                ResetButton();

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
