using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    //이 스크립트가 달려있는 물체를 움직이고 싶을때

    public float moveSpeed;
    public float jumpPower;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.MovePosition(transform.position + (new Vector3(x, 0, z) * Time.deltaTime * moveSpeed));
        //다음 프레임의 값이 Rigidbody에 의해 변함.
        //transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            //transform.Translate(Vector3.up);
            //rb.velocity = Vector3.up * jumpPower;
            rb.AddForce(Vector3.up * jumpPower,ForceMode.VelocityChange);

            //힘을 가할때 AddForce 함수를 사용
            //ForceMode
            //              중량 적용           중량무시
            //가속도 추가     .Force          .Accelerate
            //운동량 추가     .Impulse        .VelocityChagne
            
            //rb.AddTorque(); : 회전
            //rb.angularVelocity : 회전 운동량
            //rb.maxAngularVelocity : 최대 회전운동량을 제한
            //rb.maxLinearVelocity  : 최대 운동량을 제한
            //rb.drag : (공기)저항값
            //rb.angularDrag : 회전저항

            //AutoCenterofMass : 엮여있는 객체의 중간을 질량의 중심으로 만든다.

            //RigidBody의 모든 함수들은 update에서 바로 실행되는게 아니라 연산의 결과를 캐싱해놨다가
            //물리연산이 수행되는 FixedUpdate에서 적용된다.
            //입력의 처리는 Update와 lateUpdate 둘다 할수 있지만 정석은 Update이다 update의 로직이 처리되지 않기 때문에

        }

        //Physics.Raycast

        //if (Input.GetButtonDown("Fire1")) 
        //{
        //    //전방 (+Z 축으로)에 있는 콜라이더를 감지하여 만약 Enemy태그가 있으면 없애고 싶음

        //    Ray ray = new Ray(transform.position,Vector3.forward);
        //    Debug.DrawRay(ray.origin, ray.direction*10, Color.red, 0.2f);

        //    if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit ,
        //        10, 1 << LayerMask.NameToLayer("Default")));
        //    {
        //        if (hit.collider != null)
        //        {
        //            print($"콜라이더 감지 됨 : {hit.collider.name}");
                    
        //            if (hit.collider.CompareTag("Enemy"))
        //            {
        //                Destroy(hit.collider.gameObject);
        //            }
        //        }

        //    }

            
        //}

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            //Enemy 태그를 가진 물체와 충돌하면 -z 방향으로 튕겨나가고 싶다.
            rb.AddForce(Vector3.back * 100f,ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");


        ////점프
        ////InputManager를 통한 입력 제어를 하려고 할 경우
        ////모든 입력 처리는 Update에서 이루어지기 때문에
        ////FixedUpdate에서는 정확한 시점을 알기 어려움
        //transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * moveSpeed);
    }
}
