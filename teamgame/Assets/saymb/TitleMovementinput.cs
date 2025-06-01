using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    [RequireComponent(typeof(CharacterController))]
public class TitleMovementinput : MonoBehaviour
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
  
        public float moveSpeed = 3.0f;
        public float stepDistance = 2.0f;
        public float waitTime = 1.0f;
        
        private Vector3 targetPosition;
        private bool isMoving = false;

        private Vector3 moveDir;
        private float gravity = -9.81f;
        private float verticalVelocity;

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

        // Start is called before the first frame update
        void Start()
        {
            anim = this.GetComponent<Animator>();                   // Animatorを取得
            cam = Camera.main;                                       // メインカメラを取得
            controller = this.GetComponent<CharacterController>();  // CharacterControllerを取得
            targetPosition = transform.position;
            StartCoroutine(MoveStepwise());
    }

        // Update is called once per frame
        void Update()
        {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0; right.y = 0;

        Vector3 desiredDirection = (forward * v + right * h).normalized;

        if (desiredDirection != Vector3.zero && !blockRotationPlayer)
        {
            Quaternion toRotation = Quaternion.LookRotation(desiredDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, desiredRotationSpeed);
        }

        // 移動処理
        isGrounded = controller.isGrounded;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -1f; // 地面に押しつける
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }


        //// Rayをプレイヤーの前方に飛ばす
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;

        //// レイキャストを実行して、何かに当たったかを確認
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.Log("Hit object: " + hit.collider.name);
        //}

        //if (controller.isGrounded)
        //{
        //    verticalVelocity = -1f; // 接地時は落下しないよう軽く抑える
        //}
        //else
        //{
        //    verticalVelocity += gravity * Time.deltaTime;
        //}

        moveDir = desiredDirection * moveSpeed;
        moveDir.y = verticalVelocity;

        controller.Move(moveDir * Time.deltaTime);

        //アニメーション制御
        float speedPercent = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude / moveSpeed;
        anim.SetFloat("Blend", speedPercent, StartAnimTime, Time.deltaTime);
    }

    public List<Transform> movePoints;

    IEnumerator MoveStepwise()
    {
#if true
        // 0→2→4→6まで順番に移動
        //for (int index = 0; index <= 23; index++)
         for (int index = 0; index < movePoints.Count; index++)
        {
            while (Vector3.Distance(transform.position, new Vector3(movePoints[index].position.x, transform.position.y, movePoints[index].position.z)) > 0.05f)
            {
                var destination = new Vector3(movePoints[index].position.x, transform.position.y, movePoints[index].position.z);
                Vector3 moveDir = (destination - transform.position).normalized;
                controller.Move(moveDir * moveSpeed * Time.deltaTime);

                // キャラクターの向きを目的地に向けて回転させる（任意）
                if (moveDir != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, desiredRotationSpeed);
                }

                // アニメーション更新（Blend パラメータを更新）
                float speedPercent = moveDir.magnitude; // 常に1だが、スムージングのために有効
                anim.SetFloat("Blend", speedPercent, StartAnimTime, Time.deltaTime);


                yield return null;
            }
            Vector3 finalDir = (movePoints[index].position - transform.position);
            finalDir.y = 0;

            if (finalDir != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(finalDir, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 1f); // 即時に回転
            }
            // 位置をピッタリに補正
            //transform.position = new Vector3(transform.position.x, transform.position.y, z);
            //yield return new WaitForSeconds(waitTime); // 少し待ってから次に進む
        }
#else
        // 0→2→4→6まで順番に移動
        for (float z = 0; z <= 6; z += stepDistance)
        {
            
            targetPosition = new Vector3(transform.position.x, transform.position.y, z);

            while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                controller.Move(moveDir * moveSpeed * Time.deltaTime);
                yield return null;
            }

            // 位置をピッタリに補正
            //transform.position = new Vector3(transform.position.x, transform.position.y, z);
            //yield return new WaitForSeconds(waitTime); // 少し待ってから次に進む
        }
#endif
    }


}

