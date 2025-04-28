using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowOverheadView();
        }
    }

    public SwitchCamera firstPersonCamera;
    public SwitchCamera overheadCamera;

    // FPS �J�������g�p�s�ɂ��邽�߂ɂ́A���̊֐����Ăяo��
    // �I�[�o�[�w�b�h�J�������g�p�\�ɂ��܂�
    public void ShowOverheadView()
    {
        firstPersonCamera.gameObject.SetActive(false);
        overheadCamera.gameObject.SetActive(true);
    }

    // FPS �J�������g�p�\�ɂ��邽�߂ɂ́A���̊֐����Ăяo��
    // �I�[�o�[�w�b�h�J�������g�p�s�ɂ��܂�
    public void ShowFirstPersonView()
    {
        firstPersonCamera.gameObject.SetActive(true);
        overheadCamera.gameObject.SetActive(false);
    }
}
