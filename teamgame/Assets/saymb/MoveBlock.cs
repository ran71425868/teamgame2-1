using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField, Header("‘¬“x")]
    private float speed;
    private Rigidbody rb = null;

    public Vector3 moving, latestPos;
    public int selectBlock;

    private MenuSceneController menuSceneController;
    public void SetSceneController(MenuSceneController controller) => menuSceneController = controller;
    

    private int num=0;


    // true...“®‚©‚¹‚é
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            menuSceneController.select--;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            menuSceneController.select++;

        if (menuSceneController.select<=0)
        {
            menuSceneController.select = 1;
        }
        else if (menuSceneController.select >= menuSceneController.selectNumber)
        {
            menuSceneController.select = menuSceneController.selectNumber-1;
        }

        if (selectBlock == menuSceneController.select)
            MovementControll();
    }

    void MovementControll()
    {
        //var block = BlockManager.Instance.GetBlockByID(5);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            num = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            num = 0;

        }

        switch (num)
        {
            case 0:
                moving = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
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
    }

}
