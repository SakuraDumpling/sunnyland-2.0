using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    //获得刚体
    public Rigidbody2D rb;
    //获得动画切换的组件
    public Animator anim;
    //获得地面的信息
    public LayerMask ground;
    //获得player的碰撞体
    public BoxCollider2D coll;

    //声明一个速度（移动过程中需要速度）
    public float speed;
    //跳跃
    public float jumpforce;

    // Start is called before the first frame update
    //游戏一开始会执行的
    void Start()
    {

    }

    // Update is called once per frame
    //运行游戏时逐帧更新的内容
    //使用FixedUpdate函数可以优化因为硬件不同会出现的差异，每0.02秒执行一次
    void FixedUpdate()
    {
        //调用移动函数
        Movement();
        //调用跳跃动画切换函数
        SwitchAnim();
    }


    //负责移动的函数
    void Movement()
    {
        //定义一个变量用于承装输入的那个参数，方便之后判断
        //获得玩家横向输入的值，会获得3个数字型的值，0,1，-1
        float horizontalmove = Input.GetAxis("Horizontal");
        //声明一个变量用来接收获得的位置信息，这个函数GetAxisRaw只能够接收1,0，-1，更方便后续判断是否转向
        float facedircetion = Input.GetAxisRaw("Horizontal");

        //角色移动
        //判断条件
        if (horizontalmove != 0)
        {
            //获得速度的变化,vector2就是2d平面上的x,y轴移动时候的变化，3就是3d层面的
            //Vector2d的参数，（x，y）。这里是横向移动，所以y轴无变化，直接获取现在所在的位置即可
            rb.velocity = new Vector2(horizontalmove * speed * Time.fixedDeltaTime, rb.velocity.y);

            //动画效果
            //因为facedircetion获得的数据会有负数，负数会导致动画切换到另外一个状态，所以需要取绝对值.所以需要用到Mathf函数
            anim.SetBool("running", true);
        }else
        {
            //如果不等于0的时候效果是false
            anim.SetBool("running", false);
        }
        //判断是面向不是0的时候是左还是右
        if (facedircetion != 0)
        {
            //unity里的角色的transform参数等于一个新的三维参数，这里转向仅仅需要x轴的转向，所以其他两个轴默认以unity里的数值为准
            transform.localScale = new Vector3(facedircetion, 1, 1);
        }

        //角色跳跃
        //判断jump的按键按下的时候跳跃
        if(Input.GetButtonDown("Jump"))
        {
            //跳起的速度
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.fixedDeltaTime);
            //动画效果
            anim.SetBool("jumping", true);
        }
    }

    //负责下落动画切换的函数
    void SwitchAnim()
    {
        //因为idle成为ture之后会一直保持，所以开始需要给idle赋值为false
        anim.SetBool("idle", false);

        //只有跳落过程中才会有跳跃动画的切换，判断如果是在跳跃
        if(anim.GetBool("jumping"))
        {
            //如果速度小于零，那么就该触发下落的效果
            if(rb.velocity.y < 0)
            {
                //将两种动画切换过来
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        //如果不是上面的情况执行下面的，当碰撞体coll接触到ground执行
        else if(coll.IsTouchingLayers(ground))
        {
            //切换两种动画
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }
}
