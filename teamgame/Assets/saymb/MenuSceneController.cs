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

                break;

            case EToolType.Ship:
                Debug.Log($"きた {toolType}");
                GameObject instanceObj = GameObject.Instantiate(this.shipObj, this.shipParent.transform);
                instanceObj.transform.position = Vector3.zero;

                SceneManager.LoadScene("Smap", LoadSceneMode.Additive);

                break; 


        }
    }
}
