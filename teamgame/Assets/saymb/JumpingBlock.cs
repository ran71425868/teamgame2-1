using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBlock: MonoBehaviour
{
    public float bounceForce = 20f; // プレイヤーに与えるジャンプ力

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("何かがぶつかった: " + collision.gameObject.name);
        // "Player" タグがついているオブジェクトと接触した場合
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーが接触した");
            if(gameObject.name == "Jumping")
            {
            Debug.Log("Jumpingブロックにプレイヤーが乗った");
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
               if (rb != null)
               {
                // 垂直方向（Y軸）に力を加える
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // 既存のY速度をリセット
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
               }
            }
        }
    }
}


