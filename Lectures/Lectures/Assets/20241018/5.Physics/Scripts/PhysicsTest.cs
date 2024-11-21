using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    //�� ��ũ��Ʈ�� �޷��ִ� ��ü�� �����̰� ������

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
        //���� �������� ���� Rigidbody�� ���� ����.
        //transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            //transform.Translate(Vector3.up);
            //rb.velocity = Vector3.up * jumpPower;
            rb.AddForce(Vector3.up * jumpPower,ForceMode.VelocityChange);

            //���� ���Ҷ� AddForce �Լ��� ���
            //ForceMode
            //              �߷� ����           �߷�����
            //���ӵ� �߰�     .Force          .Accelerate
            //��� �߰�     .Impulse        .VelocityChagne
            
            //rb.AddTorque(); : ȸ��
            //rb.angularVelocity : ȸ�� ���
            //rb.maxAngularVelocity : �ִ� ȸ������� ����
            //rb.maxLinearVelocity  : �ִ� ����� ����
            //rb.drag : (����)���װ�
            //rb.angularDrag : ȸ������

            //AutoCenterofMass : �����ִ� ��ü�� �߰��� ������ �߽����� �����.

            //RigidBody�� ��� �Լ����� update���� �ٷ� ����Ǵ°� �ƴ϶� ������ ����� ĳ���س��ٰ�
            //���������� ����Ǵ� FixedUpdate���� ����ȴ�.
            //�Է��� ó���� Update�� lateUpdate �Ѵ� �Ҽ� ������ ������ Update�̴� update�� ������ ó������ �ʱ� ������

        }

        //Physics.Raycast

        //if (Input.GetButtonDown("Fire1")) 
        //{
        //    //���� (+Z ������)�� �ִ� �ݶ��̴��� �����Ͽ� ���� Enemy�±װ� ������ ���ְ� ����

        //    Ray ray = new Ray(transform.position,Vector3.forward);
        //    Debug.DrawRay(ray.origin, ray.direction*10, Color.red, 0.2f);

        //    if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit ,
        //        10, 1 << LayerMask.NameToLayer("Default")));
        //    {
        //        if (hit.collider != null)
        //        {
        //            print($"�ݶ��̴� ���� �� : {hit.collider.name}");
                    
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
            //Enemy �±׸� ���� ��ü�� �浹�ϸ� -z �������� ƨ�ܳ����� �ʹ�.
            rb.AddForce(Vector3.back * 100f,ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");


        ////����
        ////InputManager�� ���� �Է� ��� �Ϸ��� �� ���
        ////��� �Է� ó���� Update���� �̷������ ������
        ////FixedUpdate������ ��Ȯ�� ������ �˱� �����
        //transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * moveSpeed);
    }
}
