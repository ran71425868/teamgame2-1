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

    //int selectNumber = 1;
    //int select = 1;


    // Start is called before the first frame update
    void Start()
    {



        foreach (var cell in toolSelectCells)
        {
            cell.SetButtonClickCallback(OnClickedToolSelectCell);
        }


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

    private void CreateBlock(GameObject obj,GameObject Parent)
    {

        // ブロックを作成する
        GameObject instanceObj = GameObject.Instantiate(obj, Parent.transform);
        var block = instanceObj.GetComponent<MoveBlock>();

        //block.selectBlock = selectNumber;
        //selectNumber++;
        //select++;

        //if(selectNumber==select)
        //{
            // 作成したブロックを動かせるようにフラグを立てておく
            block.focusFlag = true;
        //}
        
        BlockManager.Instance.Add(block);

        instanceObj.transform.position = Vector3.one;

        if (!SceneManager.GetSceneByName("Smap").IsValid())
        {
            Debug.Log("Smapシーンないので生成する");
            SceneManager.LoadScene("Smap", LoadSceneMode.Additive);
        }
    }

    // ツールセレクトセルが押された際の処理
    private void OnClickedToolSelectCell(EToolType toolType) {

        switch (toolType)
        {
            case EToolType.Scaffold:
                {
                    CreateBlock(scaffoldObj, scaffoldParent);
                }

                break;

            case EToolType.Ship:

                {
                    CreateBlock(shipObj, shipParent);
                }
                
                break;

            case EToolType.Star:
                {
                    CreateBlock(starObj, starParent);
                }

                break;

            case EToolType.Beak:
                {
                    CreateBlock(beakObj, beakParent);
                }

                break;

            case EToolType.TriangularFusion:
                {
                    CreateBlock(traingularFusionObj, traingularFusionParent);
                }

                break;

            case EToolType.Rocket:
                {
                    CreateBlock(rocketObj, rocketParent);
                }

                break;

            case EToolType.BeatenUp:
                {
                    CreateBlock(beatenUpObj, beatenUpParent);
                }

                break;

            case EToolType.Pigeon:
                {
                   CreateBlock(pigeonObj, pigeonParent);
                }

                break;

            case EToolType.Triangle:
                {
                    CreateBlock(triangleObj, triangleParent);
                }

                break;

            case EToolType.Snake:
                {
                    CreateBlock(snakeObj, snakeParent);
                }

                break;

            case EToolType.Slope:
                {
                    CreateBlock(slopeObj, slopeParent);
                }

                break;

            case EToolType.Screw:
                {
                   CreateBlock(screwObj, screwParent);
                }

                break;

            case EToolType.Sasuke:
                {
                   CreateBlock(sasukeObj, sasukeParent);
                }

                break;

            case EToolType.Outlet:
                {
                    CreateBlock (outletObj, outletParent);
                }

                break;

            case EToolType.Escargot:
                {
                    CreateBlock(escargotObj, escargotParent);
                }

                break;

            case EToolType.Curve:
                {
                    CreateBlock(curveObj, curveParent);
                }

                break;
            case EToolType.Clay:
                {
                    CreateBlock(clayObj, clayParent);
                }

                break;

            case EToolType.Reset:
                {
                    ResetButton();
                    //var block = BlockManager.Instance.Removed();
                    //Destroy(block.gameObject);
                }
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
