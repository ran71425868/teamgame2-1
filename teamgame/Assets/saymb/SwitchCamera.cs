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

    // FPS カメラを使用不可にするためには、この関数を呼び出し
    // オーバーヘッドカメラを使用可能にします
    public void ShowOverheadView()
    {
        firstPersonCamera.gameObject.SetActive(false);
        overheadCamera.gameObject.SetActive(true);
    }

    // FPS カメラを使用可能にするためには、この関数を呼び出し
    // オーバーヘッドカメラを使用不可にします
    public void ShowFirstPersonView()
    {
        firstPersonCamera.gameObject.SetActive(true);
        overheadCamera.gameObject.SetActive(false);
    }
}
