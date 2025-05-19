using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField, Header("‘¬“x")]
    private float speed;
    private Rigidbody rb = null;

    public Vector3 moving, latestPos;

    private int num=0;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
       
        
        MovementControll();
    }

    void MovementControll()
    {
        //var block = BlockManager.Instance.GetBlockByID(5);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            num = 1;
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
