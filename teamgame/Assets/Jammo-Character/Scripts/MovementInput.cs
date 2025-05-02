
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    // プレイヤーの移動速度
    public float Velocity;
    [Space]

    // 入力方向のXとZ
    public float InputX;
	public float InputZ;

    // カメラ方向に基づいた移動方向
    public Vector3 desiredMoveDirection;

    // 回転を制限するフラグ
    public bool blockRotationPlayer;

    // 回転速度
    public float desiredRotationSpeed = 0.1f;

    // Animatorコンポーネント
    public Animator anim;

    // 入力ベースのスピード
    public float Speed;

    // プレイヤーの回転を許可する閾値
    public float allowPlayerRotation = 0.1f;

    // カメラ参照
    public Camera cam;

    // CharacterController参照
    public CharacterController controller;

    // 接地状態
    public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    // 垂直速度（重力用）
    public float verticalVel;

    // 移動ベクトル
    private Vector3 moveVector;

    // 初期化処理
    void Start () {
		anim = this.GetComponent<Animator> ();                   // Animatorを取得
        cam = Camera.main;                                       // メインカメラを取得
        controller = this.GetComponent<CharacterController> ();  // CharacterControllerを取得
    }

    // 毎フレーム呼ばれる
    void Update () {
		InputMagnitude ();// 入力を取得して移動処理へ

        // 接地判定と重力処理
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;// 接地しているなら垂直速度は変化なし
        }
        else
        {
            verticalVel -= 0.1f;// 落下中なら重力を加える
        }

        // 垂直方向の移動（重力影響）
        moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        controller.Move(moveVector);// 移動適用


    }

    // プレイヤーの移動と回転処理
    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

        // カメラの方向に基づく移動方向
        desiredMoveDirection = forward * InputZ + right * InputX;

        // 回転がブロックされていない場合、回転と移動を実行
        if (!blockRotationPlayer) 
        {
            // プレイヤーを回転
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);

            // 足元の地形の法線を取得
            RaycastHit hit;
            Vector3 groundNormal = Vector3.up;

            if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1.5f))
            {
                groundNormal = hit.normal;
            }

            // 地形に沿った方向へ補正
            Vector3 slopeMoveDirection = Vector3.ProjectOnPlane(desiredMoveDirection, groundNormal).normalized;

            // 移動
            controller.Move(slopeMoveDirection * Time.deltaTime * Velocity);
		}
	}

    // 指定した位置を向く
    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    // カメラ方向にプレイヤーを回転させる
    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    // 入力の大きさに応じてアニメーション制御と移動処理を実行
    void InputMagnitude() {

        // 入力取得
        InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

        // アニメーションパラメータに入力を設定（スムージングあり）
        //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        // 入力の強さ（スピード）を計算
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        // 入力があるならアニメーションを開始し、移動処理
        if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		}

        // 入力が小さいなら停止アニメーションを適用
        else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
		}
	}
}
