using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���j���[�V�[�����N�������炱������
/// </summary>
public class MenuSceneController : MonoBehaviour
{
    // �K�v�ȃI�u�W�F�N�g�����t���Ă���
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

    // �c�[���Z���N�g�Z���������ꂽ�ۂ̏���
    private void OnClickedToolSelectCell(EToolType toolType) {

        switch (toolType) { 
            case EToolType.None:

                break;

            case EToolType.Ship:

                break;


        }
    }
}
