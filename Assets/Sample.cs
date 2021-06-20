using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    //  유니티 플로우 차트
    //  https://docs.unity3d.com/kr/530/Manual/ExecutionOrder.html

    //  Initialization : 초기화 함수
    //  이 함수들은 초기화 할 때 많이 사용된다
    //  void Awake()        //  Start 함수 전에 프리팹 생성화 직후 호출
    //  void OnEnable()     //  오브젝트가 활성화 될 때 Awake 다음에 호출됨
    //  void Start()        //  스크립트 (자기 자신) 이 활성화 될 때 호출됨

    //  Updates : 계속 돌아가는 함수
    //  void FixedUpdte()   //  Update 보다 자주 호출될 수 있다. 프레임이 낮으면 낮을 수록 더 호출될 확률 증가
    //  void Update()       //  프레임마다 한 번씩 호출
    //  void LateUpdate()   //  Update 가 끝난 다음 프레임마다 한 번씩 호출

    //  Options ..
    //  void OnDisable()    //  스크립트가 비활성화 될 때 호출됨 (OnEnable 이랑 반대)
    //  void OnDestroy()    //  오브젝트가 파괴될 때 호출됨 (단 마지막 프레임에서 호출됨)

    //  C# ?
    //  class 는 뭐고 스크립트는 뭔가 ?
    //  class 는 말 그대로 '객체' 라고 하고, 스크립트는 말 그대로 코드(Code) 이다
    //  스크립트 친다 -> 코드 친다

    //  유니티 인스펙터에서 컴포넌트로 넣을 수 있는 '객체' 만드는 방법
    //  1. 반드시 public class 형식 이여야 한다
    //  2. 반드시 MonoBehavior 를 상속받아야 한다
    //  3. class 이름과 스크립트 파일 명이 동일해야 한다 (아니면 유니티에서 못 잡는다)

    //  C# 에서 변수, 함수, 클래스 선언 법
    //  C++ 이랑 완전 비슷하다!
    //  public, private, protected, internal 등등의 '접근 제한자' <- 제에에에에에ㅔ에에에에에에에발 찾아보기
    //  1. 변수는 앞에 제한자를 붙여야 하는데, 붙이지 않으면 자동으로 private 이 된다
    //  int value = 0;  //  -> private int value = 0;
    //  public int value = 0; // -> 앞에 public 이 있으므로 자동으로 유니티 Inspector 랑 연동된다
    //  Inspector 랑 연동된다 ? -> Inspector 상에서 값을 고칠 수 있다!
    //  그래서 public class 쓰라는 이유는 public 으로 해야 유니티랑 연동할 수 있기 때문!
    //  public 이면 자동으로 [SerializeField] 라는 Attribute (속성) 클래스가 붙는다
    //  요게 붙어있어야 유니티랑 연동 된다
    //  [SerializeField] private int value = 0; -> private 이라 하더라도 앞에 시리얼라이즈 속성 클래스가 있다면 연동 된다!
    //  접근 제한자 (public, private etc..) 쓰는 이유 ?
    //  Ex) A 클래스 안에 다 public 으로 하고 다른 사람이 A 클래스를 사용한다면
    //  A 클래스 안에 있는 퍼블릭들이 다 보인다
    //  1. 건드리지 말아야 할 부분을 다른 개발자가 건드릴 수 있다
    //  2. 변수 또는 함수 양에 따라 인텔리센스가 무지막지하게 많아진다
    //  3. 해킹 방어랑은 관련 없다!

    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private Transform m_AimPointTransform;
    public float m_MoveSpeed = 6.0f;
    public float m_RotateSpeed = 1.0f;

    private void Update()
    {
        //  키 변경 및 확인하는 법
        //  좌측 상단의 File -> Build Settings -> Input Manager
        float translation = Input.GetAxis("Vertical") * m_MoveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * m_RotateSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            //  Instantiate -> 클론 생성
            var go = Instantiate(m_Prefab, m_AimPointTransform.position, m_AimPointTransform.rotation, null);
            //  GetComponent ?
            //  일단, transform, gameObject 등등의 변수들은
            //  이 스크립트를 가지고 있는 객체의 대상이다
            var rigidbody = go.GetComponent<Rigidbody>();
            rigidbody.AddRelativeForce(Vector3.forward * 1000f);
        }
    }

}
