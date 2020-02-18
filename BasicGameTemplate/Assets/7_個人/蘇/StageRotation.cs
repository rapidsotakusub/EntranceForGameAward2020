using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation : MonoBehaviour
{
    //Stageについて
    float rotateSpeed = 2f;
    Quaternion currentTargetAngels;
    Quaternion oldTargetAngels;
    bool LeftRotateFlag = false;
    bool RightRotateFlag = false;
    public  Rigidbody Player;
    public Transform PlayerTransform;
    public static bool MoveFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        // Quaternion.Slerp()第二个参数需要的是四元数,所以这里需要将目标的角度转成四元数去计算
        currentTargetAngels = Quaternion.Euler(0, 0, 0f);
        oldTargetAngels = Quaternion.Euler(0, 0, 0f);

        Player.useGravity = true;  //Default状況でPlayerの重力があります
        MoveFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //LButton
        if (Input.GetButtonDown("LButton")&& LeftRotateFlag == false && RightRotateFlag == false)
        {
            //transform.Rotate(0, 0, 90);
            print("LButton");
            oldTargetAngels = currentTargetAngels;
            LeftRotateFlag = true;
            if (oldTargetAngels == Quaternion.Euler(0, 0, 0f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, 90f);
            }
            if (oldTargetAngels == Quaternion.Euler(0, 0, 90f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, 180f);
            }
            if (oldTargetAngels == Quaternion.Euler(0, 0, -180f) || oldTargetAngels == Quaternion.Euler(0, 0, 180f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, -90f);
            }
            if (oldTargetAngels == Quaternion.Euler(0, 0, -90f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, 0f);
            }
        }
        //RButton
        if (Input.GetButtonDown("RButton") && LeftRotateFlag == false && RightRotateFlag == false)
        {
            oldTargetAngels = currentTargetAngels;
            //transform.Rotate(0, 0, -90);
            print("RButton");
            RightRotateFlag = true;
            if (oldTargetAngels == Quaternion.Euler(0, 0, 0f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, -90f);
            }
            if (oldTargetAngels == Quaternion.Euler(0, 0, 90f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, 0f);
            }
            if (oldTargetAngels == Quaternion.Euler(0, 0, -180f) || oldTargetAngels == Quaternion.Euler(0, 0, 180f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, 90f);
            }
            if (oldTargetAngels == Quaternion.Euler(0, 0, -90f))
            {
                currentTargetAngels = Quaternion.Euler(0, 0, 180f);
            }
        }


        //LeftRotation
        if (LeftRotateFlag)
        {
            //StageRotation
            Player.useGravity = false;  //Default状況でPlayerの重力がない
            MoveFlag = false;
            //  用 slerp 进行插值平滑的旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, currentTargetAngels, rotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(currentTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = currentTargetAngels;        //旋转到目标角度     
                LeftRotateFlag = false;                          //停止旋转停止旋转,恢复到可以旋转的状态
            }
            //PlayerRotation
            //  用 slerp 进行插值平滑的旋转
            PlayerTransform.rotation = Quaternion.Slerp(PlayerTransform.rotation, currentTargetAngels, rotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(currentTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = currentTargetAngels;        //旋转到目标角度     
                LeftRotateFlag = false;                          //停止旋转停止旋转,恢复到可以旋转的状态
            }
        }     
        //RightRotation
        else if (RightRotateFlag)
        {
            Player.useGravity = false;  //Default状況でPlayerの重力がない
            MoveFlag = false;
            //  用 slerp 进行插值平滑的旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, currentTargetAngels, rotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(currentTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = currentTargetAngels;        //旋转到目标角度     
                RightRotateFlag = false;                         //停止旋转,恢复到可以旋转的状态
            }

        }
        else
        {
            Player.useGravity = true;  //Default状況でPlayerの重力があります
            if (FootCollision.grounded == true)
            {
                MoveFlag = true;
            }
            
        }
        
    }

}
