using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public enum CameraType
    {
        First,
        OverHead
    }

    public CameraType CurrentCType = CameraType.First;
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        switch (CurrentCType)
        {
            case CameraType.First:
                ShowOverheadView();
                break;

                case CameraType.OverHead:
                ShowFirstPersonView();
                break;
        }
    }


    // FPS カメラを使用不可にするためには、この関数を呼び出し
    // オーバーヘッドカメラを使用可能にします
    public void ShowOverheadView()
    {
        firstPersonCamera.gameObject.SetActive(false);
        overheadCamera.gameObject.SetActive(true);

        CurrentCType=CameraType.OverHead;
    }

    // FPS カメラを使用可能にするためには、この関数を呼び出し
    // オーバーヘッドカメラを使用不可にします
    public void ShowFirstPersonView()
    {
        firstPersonCamera.gameObject.SetActive(true);
        overheadCamera.gameObject.SetActive(false);

        CurrentCType = CameraType.First;
    }
}
