
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{

    // プレイヤーの移動速度
    public float Velocity;
    [Space]

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
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    // 垂直速度（重力用）
    public float verticalVel;

    // 移動ベクトル
    private Vector3 moveVector;

    [SerializeField]
    private Transform targetTransform;//ターゲット
    private NavMeshAgent m_Agent;//自動経路探索

    //西田　ジャンプ制御用
    [Header("ジャンプ設定")]
    public float jumpHeight = 6.0f;
    public float jumpDuration = 0.8f;
    private bool isJumping = false;

    [Header("足音設定")]
    public AudioClip footstepClip;
    public float footstepInterval = 0.5f;

    private AudioSource audioSource;
    private float footstepTimer = 0f;

    // 初期化処理
    void Start()
    {
        anim = this.GetComponent<Animator>();                   // Animatorを取得
        cam = Camera.main;                                       // メインカメラを取得
        controller = this.GetComponent<CharacterController>();  // CharacterControllerを取得
        m_Agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        //"Target"という名前のGameObjectを探してセット
        GameObject targetObject = GameObject.Find("Target");
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
        }

        if (targetTransform == null)
        {
            Debug.LogWarning("targetTransformが設定されていません！");
        }
        else
        {
            Debug.Log("targetTransformが正常に設定されています:" + targetTransform.name);
        }

        if (m_Agent != null)
        {
            Debug.Log("NavMeshAgent は有効か？ => " + m_Agent.enabled);
        }
        else
        {
            Debug.LogError("NavMeshAgent が取得できていません！");
        }


    }
    // 毎フレーム呼ばれる
    void Update()
    {
        if (targetTransform != null && !isJumping)//西田　&& !isJumping
        {
            m_Agent.SetDestination(targetTransform.position);

            //回転処理
            RotateTowards(m_Agent.steeringTarget);

            //アニメーション制御
            float speedpercent = m_Agent.velocity.magnitude / m_Agent.speed;
            anim.SetFloat("Blend", speedpercent, StartAnimTime, Time.deltaTime);
        }

        //InputMagnitude();// 入力を取得して移動処理へ

        // 接地判定と重力処理
        //isGrounded = controller.isGrounded;//   西田　グラビティ削除
        //if (isGrounded)
        //{
        //    verticalVel -= 0;// 接地しているなら垂直速度は変化なし
        //}
        //else
        //{
        //    verticalVel -= 1;// 落下中なら重力を加える
        //}
        if (isGrounded)
        {
            verticalVel -= 1;// 接地しているなら垂直速度は変化なし
        }

        // 垂直方向の移動（重力影響）
        //moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        //controller.Move(moveVector);// 移動適用


        // 足音処理（移動中かつ接地中）
        if (m_Agent.enabled&& m_Agent.remainingDistance > m_Agent.stoppingDistance)
        {
            Debug.Log("足音再生！");
            footstepTimer += Time.deltaTime;

            if (footstepTimer >= footstepInterval && !audioSource.isPlaying)
            {
                audioSource.clip = footstepClip;
                audioSource.Play();
                footstepTimer = 0f;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }
    //西田　下のをここに移動
    private void RotateTowards(Vector3 target)
    {
        Vector3 direcction = (target - transform.position).normalized;
        direcction.y = 0;
        if (direcction.magnitude >= 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direcction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, desiredRotationSpeed);
        }
    }
    // プレイヤーの移動と回転処理
    //void PlayerMoveAndRotation()
    //{
    //    InputX = Input.GetAxis("Horizontal");
    //    InputZ = Input.GetAxis("Vertical");

    //    var camera = Camera.main;
    //    var forward = cam.transform.forward;
    //    var right = cam.transform.right;

    //    forward.y = 0f;
    //    right.y = 0f;

    //    forward.Normalize();
    //    right.Normalize();

    //    // カメラの方向に基づく移動方向
    //    desiredMoveDirection = forward * InputZ + right * InputX;

    //    // 回転がブロックされていない場合、回転と移動を実行
    //    if (!blockRotationPlayer)
    //    {
    //        // プレイヤーを回転
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);

    //        // 足元の地形の法線を取得
    //        RaycastHit hit;
    //        Vector3 groundNormal = Vector3.up;

    //        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1.5f))
    //        {
    //            groundNormal = hit.normal;
    //        }

    //        // 地形に沿った方向へ補正
    //        Vector3 slopeMoveDirection = Vector3.ProjectOnPlane(desiredMoveDirection, groundNormal).normalized;

    //        // 移動
    //        controller.Move(slopeMoveDirection * Time.deltaTime * Velocity);
    //    }
    //}

    // 指定した位置を向く
    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    // カメラ方向にプレイヤーを回転させる
    public void RotateToCamera(Transform t)
    {

       //var camera = Camera.main;　//西田　コメントアウト
        var forward = cam.transform.forward;
        //var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("JumpPad") && !isJumping)
    //    {
    //        Transform jumpTarget = other.transform; // ジャンプ台のTransformから方向と位置を取得
    //        StartCoroutine(JumpOverObstacle(jumpTarget));
    //    }
    //}
    //西田 jumpOverObstacle　追加
    public IEnumerator JumpOverObstacle(Transform jumpPad,float jumpForce)
    {
        isJumping = true;
        m_Agent.enabled = false;

        // 当たった相手のRigidbodyコンポーネントを取得して、上向きの力を加える
        GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);

        Vector3 startPos = transform.position;
        //Vector3 endPos = jumpPad.position + jumpPad.forward * 5f; // 飛び先はジャンプ台の前方5メートル
   
        Vector3 endPos = transform.position + transform.forward * 5f; // 飛び先はジャンプ台の前方5メートル
        float elapsed = 0f;

        while (elapsed < jumpDuration)
        {
            float t = elapsed / jumpDuration;
            float height = Mathf.Sin(Mathf.PI * t) * jumpHeight;
            transform.position = Vector3.Lerp(startPos, endPos, t) + Vector3.up * height;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        m_Agent.enabled = true;

        // 目的地に戻す（必要があれば）
        if (targetTransform != null)
        {
            m_Agent.SetDestination(targetTransform.position);
        }

        isJumping = false;
    }
    //// 入力の大きさに応じてアニメーション制御と移動処理を実行
    //void InputMagnitude()
    //{

    //    // 入力取得
    //    InputX = Input.GetAxis("Horizontal");
    //    InputZ = Input.GetAxis("Vertical");

    //    // アニメーションパラメータに入力を設定（スムージングあり）
    //    //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
    //    //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

    //    // 入力の強さ（スピード）を計算
    //    Speed = new Vector2(InputX, InputZ).sqrMagnitude;

    //    // 入力があるならアニメーションを開始し、移動処理
    //    if (Speed > allowPlayerRotation)
    //    {
    //        anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
    //        PlayerMoveAndRotation();
    //    }

    //    // 入力が小さいなら停止アニメーションを適用
    //    else if (Speed < allowPlayerRotation)
    //    {
    //        anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
    //    }
    //}

    //西田　上に位置変更
    //private void RotateTowards(Vector3 target)
    //{
    //    Vector3 direcction = (target - transform.position).normalized;
    //    direcction.y = 0;
    //    if (direcction.magnitude >= 0.1f)
    //    {
    //        Quaternion lookRotation = Quaternion.LookRotation(direcction);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, desiredRotationSpeed);
    //    }
    //}
}
