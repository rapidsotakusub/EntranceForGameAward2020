using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollision : MonoBehaviour
{
    public static bool grounded;

    // 获取Player变量指定的对象的三围坐标
    public GameObject Player;
   
    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 player_postion = Player.transform.position;
        //// 获取X,Y,Z值
        //float x = player_postion.x;
        //float y = player_postion.y;
        //float z = player_postion.z;
        //// 设置应用了当前函数的GameObject的坐标
        //this.GetComponent<Transform>().position = player_postion + new Vector3(0, -0.45F, 0);
    }

    //碰撞检测Stay
    private void OnCollisionStay(Collision collision)     {         if (collision.collider.tag == "ground")         {             grounded = true;         }     }
    //碰撞检测Exit
    private void OnCollisionExit(Collision collision)     {         if (collision.collider.tag == "ground")         {             grounded = false;         }     }
}
