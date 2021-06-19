using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator m_Animator;
    //[SerializeField] public Animator m_Animator;
    //  �� �ڵ�� �Ȱ���
    //  1. [SerializeField] �� �־�� Inspector â�� ���δ�
    //  2. public �� ��� �ڵ����� "[SerializeField]" ������ �ٴ´�
    //  ���� public �ε� Inspector �� �Ⱥ��̰� �ʹٸ�
    //  [System.NonSerialized] �� �ٿ��� �Ѵ�
    public float m_Speed;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        m_Animator.SetBool("isMove", false);

        if (Input.GetKey(KeyCode.W))
        {
            m_Animator.SetBool("isMove", true);
            transform.Translate(0, 0, -m_Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_Animator.SetBool("isMove", true);
            transform.Translate(0, 0, m_Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_Animator.SetBool("isMove", true);
            transform.Translate(m_Speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_Animator.SetBool("isMove", true);
            transform.Translate(-m_Speed, 0, 0);
        }

    }
}
