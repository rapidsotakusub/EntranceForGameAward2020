using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.5f;
    float moveSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //通过刚体控制物体移动,需要添加刚体
        // 使用时未成功
        //Vector3 moveForward = Vector3.zero;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    moveForward.z += 1;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    moveForward.z += -1;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    moveForward.x += -1;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveForward.x += 1;
        //}

        //GetComponent<Rigidbody>().MovePosition(Quaternion.LookRotation(transform.forward) * moveForward * moveSpeed);


        ////-----------------------------------------方法三 使用unity自带的移动方式----------------
        //float H = Input.GetAxis("Horizontal");
        //float V = Input.GetAxis("Vertical");
        //if (H != 0 || V != 0)
        //{
        //    transform.Translate(new Vector3(H, 0, V) * Time.deltaTime * moveSpeed, Space.World);
        //}
        //else
        //{
        //    //没有移动
        //}

        /////-----------------------------------------方法二 常规方法-----------------------------
        /// 移动时 正常
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //}


        /////-----------------------------------------方法一-----------------------------
        ///// 移动时 不流畅
        ////上
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //    transform.position += transform.forward * speed;
        //}
        ////下
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //    transform.position += transform.forward * speed;
        //}
        ////左
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 270, 0);
        //    transform.position += transform.forward * speed;
        //}
        ////右
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.eulerAngles = new Vector3(0, 90, 0);
        //    transform.position += transform.forward * speed;
        //}

    }
}
