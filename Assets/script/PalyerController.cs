using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    //获得刚体
    public Rigidbody2D rb;
    //声明一个速度（移动过程中需要速度）
    public float speed;

    // Start is called before the first frame update
    //游戏一开始会执行的
    void Start()
    {
        
    }

    // Update is called once per frame
    //运行游戏时逐帧更新的内容
    void Update()
    {
        //调用移动函数
        Movement();
    }


    //负责移动的函数
    void Movement()
    {
        //定义一个变量用于承装输入的那个参数，方便之后判断
        //获得玩家横向输入的值，会获得3个数字型的值，0,1，-1
        float horizontalmove = Input.GetAxis("Horizontal");
        //声明一个变量用来接收获得的位置信息，这个函数GetAxisRaw只能够接收1,0，-1，更方便后续判断是否转向
​        float facedircetion = Input.GetAxisRaw("Horizontal");

        //判断条件
        if (horizontalmove != 0)
        {
            //获得速度的变化,vector2就是2d平面上的x,y轴移动时候的变化，3就是3d层面的
            //Vector2d的参数，（x，y）。这里是横向移动，所以y轴无变化，直接获取现在所在的位置即可
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }

        //判断是面向不是0的时候是左还是右
        if (facedircetion != 0)
        {
            //unity里的角色的transform参数等于一个新的三维参数，这里转向仅仅需要x轴的转向，所以其他两个轴默认以unity里的数值为准
            transform.localScale = new Vector3(facedircetion, 1, 1);
        }
    }
}
