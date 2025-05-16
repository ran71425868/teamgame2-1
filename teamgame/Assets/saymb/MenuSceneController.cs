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

    //[SerializeField] extern public MoveBlock MovementControll();

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
                instanceObj.transform.position = Vector3.one;

                SceneManager.LoadScene("Smap", LoadSceneMode.Additive);

                break;

            case EToolType.Ship:


                //Debug.Log($"きた {toolType}");
                instanceObj = GameObject.Instantiate(this.shipObj, this.shipParent.transform);
                instanceObj.transform.position = Vector3.one;

                SceneManager.LoadScene("Smap", LoadSceneMode.Additive);

                break;

            case EToolType.Reset:

                ResetButton();

                break;

        }
    }
}
