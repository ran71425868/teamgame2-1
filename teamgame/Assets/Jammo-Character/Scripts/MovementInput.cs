
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    // �v���C���[�̈ړ����x
    public float Velocity;
    [Space]

    // ���͕�����X��Z
    public float InputX;
	public float InputZ;

    // �J���������Ɋ�Â����ړ�����
    public Vector3 desiredMoveDirection;

    // ��]�𐧌�����t���O
    public bool blockRotationPlayer;

    // ��]���x
    public float desiredRotationSpeed = 0.1f;

    // Animator�R���|�[�l���g
    public Animator anim;

    // ���̓x�[�X�̃X�s�[�h
    public float Speed;

    // �v���C���[�̉�]��������臒l
    public float allowPlayerRotation = 0.1f;

    // �J�����Q��
    public Camera cam;

    // CharacterController�Q��
    public CharacterController controller;

    // �ڒn���
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

    // �������x�i�d�͗p�j
    public float verticalVel;

    // �ړ��x�N�g��
    private Vector3 moveVector;

    // ����������
    void Start () {
		anim = this.GetComponent<Animator> ();                   // Animator���擾
        cam = Camera.main;                                       // ���C���J�������擾
        controller = this.GetComponent<CharacterController> ();  // CharacterController���擾
    }

    // ���t���[���Ă΂��
    void Update () {
		InputMagnitude ();// ���͂��擾���Ĉړ�������

        // �ڒn����Əd�͏���
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;// �ڒn���Ă���Ȃ琂�����x�͕ω��Ȃ�
        }
        else
        {
            verticalVel -= 0.1f;// �������Ȃ�d�͂�������
        }

        // ���������̈ړ��i�d�͉e���j
        moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        controller.Move(moveVector);// �ړ��K�p


    }

    // �v���C���[�̈ړ��Ɖ�]����
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

        // �J�����̕����Ɋ�Â��ړ�����
        desiredMoveDirection = forward * InputZ + right * InputX;

        // ��]���u���b�N����Ă��Ȃ��ꍇ�A��]�ƈړ������s
        if (!blockRotationPlayer) 
        {
            // �v���C���[����]
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);

            // �����̒n�`�̖@�����擾
            RaycastHit hit;
            Vector3 groundNormal = Vector3.up;

            if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1.5f))
            {
                groundNormal = hit.normal;
            }

            // �n�`�ɉ����������֕␳
            Vector3 slopeMoveDirection = Vector3.ProjectOnPlane(desiredMoveDirection, groundNormal).normalized;

            // �ړ�
            controller.Move(slopeMoveDirection * Time.deltaTime * Velocity);
		}
	}

    // �w�肵���ʒu������
    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    // �J���������Ƀv���C���[����]������
    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    // ���͂̑傫���ɉ����ăA�j���[�V��������ƈړ����������s
    void InputMagnitude() {

        // ���͎擾
        InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

        // �A�j���[�V�����p�����[�^�ɓ��͂�ݒ�i�X���[�W���O����j
        //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        // ���͂̋����i�X�s�[�h�j���v�Z
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        // ���͂�����Ȃ�A�j���[�V�������J�n���A�ړ�����
        if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		}

        // ���͂��������Ȃ��~�A�j���[�V������K�p
        else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
		}
	}
}
