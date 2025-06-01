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

    [SerializeField] private GameObject jumpPadObj = null;
    [SerializeField] private GameObject jumpPadParent = null;

    [SerializeField] private GameObject sasukeObj = null;
    [SerializeField] private GameObject sasukeParent = null;

    [SerializeField] private GameObject outletObj = null;
    [SerializeField] private GameObject outletParent = null;

    //[SerializeField] private GameObject escargotObj = null;
    //[SerializeField] private GameObject escargotParent = null;

    [SerializeField] private GameObject curveObj = null;
    [SerializeField] private GameObject curveParent = null;

    [SerializeField] private GameObject clayObj = null;
    [SerializeField] private GameObject clayParent = null;

    private int selectNumber = 1;
    public int select = 1;

    [SerializeField] private AudioClip createBlockSE;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceを取得（なければ自動追加）
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        foreach (var cell in toolSelectCells)
        {
            cell.SetButtonClickCallback(OnClickedToolSelectCell);
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.select--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.select++;
        }

        if (this.select <= 1)
        {
            this.select = 1;
        }
        else if (this.select >= this.selectNumber - 1)
        {
            this.select = this.selectNumber - 1;
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

        // SE再生
        if (createBlockSE != null && audioSource != null)
        {
            audioSource.PlayOneShot(createBlockSE);
        }

        // ブロックを作成する
        GameObject instanceObj = GameObject.Instantiate(obj, Parent.transform);
        var block = instanceObj.GetComponent<MoveBlock>();

        block.selectBlock = selectNumber;
        selectNumber++;
        select = block.selectBlock;


        block.SetSceneController(this);
        //if(selectNumber==select)
        //{
        // 作成したブロックを動かせるようにフラグを立てておく
        //block.focusFlag = true;
        //}
        
        BlockManager.Instance.Add(block);

        instanceObj.transform.position = Vector3.one;
        //if (!SceneManager.GetSceneByName("Stage_1").IsValid())
        // {
        //     Debug.Log("Stage_1シーンないので生成する");
        //     SceneManager.LoadScene("Stage_1", LoadSceneMode.Additive);
        // }
        // break;
    }

    // ツールセレクトセルが押された際の処理
    private void OnClickedToolSelectCell(EToolType toolType) {
        Debug.Log($"Click:{toolType}");
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

            case EToolType.JumpPad:
                {
                   CreateBlock(jumpPadObj, jumpPadParent);
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

            //case EToolType.Escargot:
            //    {
            //        CreateBlock(escargotObj, escargotParent);
            //    }

            //    break;

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

            case EToolType.Back:
                {
                    selectNumber--;
                    var block = BlockManager.Instance.Removed(select,selectNumber);

                    Destroy(block.gameObject);
                }
               
                break;

            case EToolType.Reset:
                {
                    ResetButton();
                }
                break;

        }
    }
}
