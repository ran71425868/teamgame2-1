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

    public SwitchCamera CameraNum;
    [SerializeField] private int num;

    [SerializeField] private  Vector3 rotationSpeedQ = new Vector3(0, 0, 0); // 回転速度 (x, y, z); 
    [SerializeField] private  Vector3 rotationSpeedE = new Vector3(0, 0, 0); // 回転速度 (x, y, z); 


    private MenuSceneController menuSceneController;
    public void SetSceneController(MenuSceneController controller) => menuSceneController = controller;

    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    // true...動かせる
    //public bool focusFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (selectBlock == menuSceneController.select)
        //{
        //    MovementControll();
        //    GetComponent<Renderer>().material = selectedMaterial;
        //}
        //else
        //{
        //    GetComponent<Renderer>().material = defaultMaterial;
        //}

        var renderer = GetComponent<Renderer>();
        var mats = renderer.materials;

        if (selectBlock == menuSceneController.select)
        {
            MovementControll();

            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = selectedMaterial;
            }
        }
        else
        {
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = defaultMaterial;
            }
        }

        renderer.materials = mats;
    }

    void MovementControll()
    {

        if (Input.GetKeyDown(KeyCode.Space) && num > 0)
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

        if (Input.GetKey(KeyCode.Q))
        {
           
            // オブジェクトを毎フレームY軸を中心に回転させる
            transform.Rotate(rotationSpeedQ * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
      
            // オブジェクトを毎フレームY軸を中心に回転させる
            transform.Rotate(rotationSpeedE * Time.deltaTime);
        }
    }

}
