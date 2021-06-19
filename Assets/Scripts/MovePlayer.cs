using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator m_Animator;
    //[SerializeField] public Animator m_Animator;
    //  요 코드랑 똑같음
    //  1. [SerializeField] 가 있어야 Inspector 창에 보인다
    //  2. public 인 경우 자동으로 "[SerializeField]" 문구가 붙는다
    //  만약 public 인데 Inspector 에 안보이고 싶다면
    //  [System.NonSerialized] 를 붙여야 한다
    public CharacterController m_Controller;
    public Transform m_CameraTransform;
    public Transform m_AimPoint;
    public GameObject m_BulletPrefab;
    public Transform m_BodyTransform;
    public float m_ShootPower = 1000.0f;
    public float m_Gravity = 9.81f;
    public float m_JumpHeight = 2.0f;
    public float m_RotateSpeed = 1.0f;
    public float m_MoveSpeed = 6.0f;
    private Vector2 m_RotateAxis;
    private float m_GravityTimer = 0;
    private float m_FixRotateX = 0;
    private float m_VerticalVelocity = 0;
    private bool m_isEnableCursor = false;

    private void Awake()
    {
        Vector3 euler = m_CameraTransform.eulerAngles;

        m_RotateAxis = new Vector2(euler.y, euler.x);
        m_FixRotateX = m_RotateAxis.x;

        EnableCursor(m_isEnableCursor);
    }

    private void Update()
    {
        UpdateRotate();
        UpdateMove();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(m_BulletPrefab, m_AimPoint.position, m_AimPoint.rotation, null);
            go.GetComponent<Bullet>().Shoot(m_ShootPower);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            EnableCursor(!m_isEnableCursor);
    }

    private void EnableCursor(bool isEnable)
    {
        Cursor.lockState = isEnable ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = isEnable;

        m_isEnableCursor = isEnable;
    }

    private void UpdateRotate()
    {
        m_RotateAxis.x += Input.GetAxis("Mouse X") * m_RotateSpeed;
        m_RotateAxis.y += Input.GetAxis("Mouse Y") * m_RotateSpeed;

        m_CameraTransform.localRotation = Quaternion.Euler(-m_RotateAxis.y, m_FixRotateX, 0);
        transform.localRotation = Quaternion.Euler(0, m_FixRotateX + m_RotateAxis.x, 0);

        m_BodyTransform.localRotation = Quaternion.Euler(m_RotateAxis.y, 0, 0);
    }

    private void UpdateMove()
    {
        if (m_Controller.isGrounded) m_GravityTimer = 0.2f;
        if (m_GravityTimer > 0) m_GravityTimer -= Time.deltaTime;

        if (m_Controller.isGrounded && m_VerticalVelocity < 0)
            m_VerticalVelocity = 0;

        if (Input.GetButtonDown("Jump"))
        {
            if (m_GravityTimer > 0)
            {
                m_GravityTimer = 0;
                m_VerticalVelocity += Mathf.Sqrt(m_JumpHeight * 2.0f * m_Gravity);
            }
        }

        m_VerticalVelocity -= m_Gravity * Time.deltaTime;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(-horizontal, 0, -vertical);
        direction = transform.TransformDirection(direction);
        direction *= m_MoveSpeed;

        direction.y = m_VerticalVelocity;
        if (direction.x != 0 && direction.z != 0) m_Animator.SetBool("isMove", true);
        else m_Animator.SetBool("isMove", false);

        m_Controller.Move(direction * Time.deltaTime);
    }
}
