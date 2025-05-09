using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{


    public Rigidbody rb;
    public Vector3 moving, latestPos;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        MovementControll();
        Movement();
    }

    //void FixedUpdate()
    //{
    //    RotateToMovingDirection();
    //}

    void MovementControll()
    {
        moving = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0 );
        moving.Normalize();
        moving = moving * speed;
    }

    //public void RotateToMovingDirection()
    //{
    //    Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
    //    latestPos = transform.position;
       
    //    if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
    //    {
    //        Quaternion rot = Quaternion.LookRotation(differenceDis);
    //        rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.1f);
    //        this.transform.rotation = rot;
    //    }
    //}

    void Movement()
    {
        //rb.velocity = moving;
    }

}
