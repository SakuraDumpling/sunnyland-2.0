using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    //��ø���
    public Rigidbody2D rb;
    //����һ���ٶȣ��ƶ���������Ҫ�ٶȣ�
    public float speed;

    // Start is called before the first frame update
    //��Ϸһ��ʼ��ִ�е�
    void Start()
    {
        
    }

    // Update is called once per frame
    //������Ϸʱ��֡���µ�����
    void Update()
    {
        //�����ƶ�����
        Movement();
    }


    //�����ƶ��ĺ���
    void Movement()
    {
        //����һ���������ڳ�װ������Ǹ�����������֮���ж�
        float horizontalmove;
        //�����Һ��������ֵ������3�������͵�ֵ��0,1��-1
        horizontalmove = Input.GetAxis("Horizontal");
        //�ж�����
        if (horizontalmove != 0)
        {
            //����ٶȵı仯,vector2����2dƽ���ϵ�x,y���ƶ�ʱ��ı仯��3����3d�����
            //Vector2d�Ĳ�������x��y���������Ǻ����ƶ�������y���ޱ仯��ֱ�ӻ�ȡ�������ڵ�λ�ü���
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }
    }
}
