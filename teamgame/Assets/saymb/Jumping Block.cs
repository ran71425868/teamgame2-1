using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping
{
    public float bounceForce = 10f; // プレイヤーに与えるジャンプ力

    private void OnCollisionEnter(Collision collision)
    {
        // "Player" タグがついているオブジェクトと接触した場合
        if (collision.gameObject.CompareTag("Player"))
        {
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


