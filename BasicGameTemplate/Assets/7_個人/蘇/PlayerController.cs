using System.Collections; using System.Collections.Generic; using UnityEngine;  public class PlayerController : MonoBehaviour {     //float speed = 0.5f;     public float moveSpeed = 5f;          public Rigidbody playerRigidbody;     public float jumpForce = 50.0f;     public Quaternion currentPlayerTargetAngels;
    public Quaternion oldPlayerTargetAngels;     public float playerRotateSpeed = 2f;      // Start is called before the first frame update     void Start()     {              }      // Update is called once per frame     void Update()     {         //LeftRotation
        if (StageRotation.LeftRotateFlag)
        {
            //  用 slerp 进行插值平滑的旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, currentPlayerTargetAngels, playerRotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(StageRotation.currentTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = StageRotation.currentTargetAngels;        //旋转到目标角度     
                StageRotation.LeftRotateFlag = false;                          //停止旋转停止旋转,恢复到可以旋转的状态
            }

        }
        //RightRotation
        else if (StageRotation.RightRotateFlag)
        {
            //  用 slerp 进行插值平滑的旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, StageRotation.currentTargetAngels, StageRotation.rotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(StageRotation.currentTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = StageRotation.currentTargetAngels;        //旋转到目标角度     
                StageRotation.RightRotateFlag = false;                         //停止旋转,恢复到可以旋转的状态
            }

        }
      }     void FixedUpdate()     {                  if (StageRotation.MoveFlag == true)         {             //Move             float H = Input.GetAxis("LeftStickHorizontal");             float V = Input.GetAxis("LeftStickVertical");             if (H != 0 || V != 0)             {                 transform.Translate(new Vector3(H, 0, 0) * Time.deltaTime * moveSpeed, Space.World);             }             else             {                 //没有移动             }             //Jump             if (FootCollision.grounded == true)             {                 //ADownButton                 if (Input.GetButtonDown("ADownButton"))                 {                     print("ADownButton");                     playerRigidbody.AddForce(new Vector3(0f, jumpForce, 0f));                     FootCollision.grounded = false;                 }              }                       }               }  } 