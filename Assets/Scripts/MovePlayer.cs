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
