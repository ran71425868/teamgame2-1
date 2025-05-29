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

    private int num = 0;


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
        if (selectBlock == menuSceneController.select)
            MovementControll();
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
    }

}
