using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class MoveBlock : MonoBehaviour
{
    [SerializeField, Header("速度")]
    private float speed;
    private Rigidbody rb = null;

    public Vector3 moving, latestPos;
    public int selectBlock;

    public Vector3 rotationSpeed; 


    private MenuSceneController menuSceneController;
    public void SetSceneController(MenuSceneController controller) => menuSceneController = controller;

    private int num = 0;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    // true...動かせる
    //public bool focusFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = 5;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (selectBlock == menuSceneController.select)
        {
            MovementControll();
            GetComponent<Renderer>().material = selectedMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = defaultMaterial;
        }
    }

    void MovementControll()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&num>0)
        {
            num = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            num = 1;
        }
        
        switch (num)
        {
            case 0:

                moving = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
                moving.Normalize();
                moving = moving * speed;

                break;

            case 1:

                moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                moving.Normalize();
                moving = moving * speed;
                
                break;

        }

        transform.position = transform.position + (moving * speed) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotationSpeed = new Vector3(0, 0, 90); // 回転速度 (x, y, z)
            // オブジェクトを毎フレームY軸を中心に回転させる
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // 目標の回転角度
            Quaternion targetRotation = Quaternion.Euler(0, 0, -90);

            // 現在の回転から目標回転へスムーズに補間
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }

}
