using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class MoveBlock : MonoBehaviour
{
    [SerializeField, Header("速度")]
    private float speed;
    private Rigidbody rb = null;

    public Vector3 latestPos;
    public int selectBlock;

    private Vector3 velocity;

    private SwitchCamera switchCamera;
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
        switchCamera = GameObject.FindAnyObjectByType<SwitchCamera>();
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

        if (selectBlock == menuSceneController?.select)
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
        velocity = Vector3.zero;


        //if (Input.GetKeyDown(KeyCode.Space) && num > 0)
        //{
        //    num = 0;
        //}
        //else if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    num = 1;
        //}

        switch (switchCamera.CurrentCType)
        {
            case SwitchCamera.CameraType.First:

                if (Input.GetKey(KeyCode.W))
                {
                    //transform.position += speed * transform.up * Time.deltaTime;
                    velocity.y += 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    //transform.position -= speed * transform.up * Time.deltaTime;
                    velocity.y -= 1;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    //transform.position += speed * transform.right * Time.deltaTime;
                    velocity.x += 1;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    //transform.position -= speed * transform.right * Time.deltaTime;
                    velocity.x -= 1;
                }

                break;

            case SwitchCamera.CameraType.OverHead:

                if (Input.GetKey(KeyCode.W))
                {
                    //transform.position += speed * transform.forward * Time.deltaTime;
                    velocity.z += 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    //transform.position -= speed * transform.forward * Time.deltaTime;
                    velocity.z -= 1;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    //transform.position += speed * transform.right * Time.deltaTime;
                    velocity.x += 1;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    //transform.position -= speed * transform.right * Time.deltaTime;
                    velocity.x -= 1;
                }

                break;

        }

        velocity = velocity.normalized * speed * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }


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
