using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AutoJumping : MonoBehaviour
{
    // ジャンプする力（上向きの力）を定義
    [SerializeField] private float jumpForce = 20.0f;
    /// <summary>
    /// Colliderが他のトリガーに入った時に呼び出される
    /// </summary>
    /// <param/* name="other*/">当たった相手のオブジェクト</param>
    public void OnTriggerEnter(Collider other)
    {
        // 当たった相手のタグがPlayerだった場合
        if (other.CompareTag("Player"))
        {
            Debug.Log("あたった");

            StartCoroutine(other.gameObject.GetComponent<MovementInput>().JumpOverObstacle(this.transform, jumpForce));
        }
    }


}
