using System.Collections; using System.Collections.Generic; using UnityEngine;  public class PlayerController : MonoBehaviour {     //public static bool grounded;     //float speed = 0.5f;     public float moveSpeed = 5f;          public Rigidbody playerRigidbody;     public float jumpForce = 50.0f;     public static Quaternion currentPlayerTargetAngels;
    public static Quaternion oldPlayerTargetAngels;     public float playerRotateSpeed = 2f;      // Start is called before the first frame update     void Start()     {         FootCollision.grounded = true;         // Quaternion.Slerp()第二个参数需要的是四元数,所以这里需要将目标的角度转成四元数去计算
        oldPlayerTargetAngels = Quaternion.Euler(0, 0, 0f);
        currentPlayerTargetAngels = Quaternion.Euler(0, 90f, 0);            }      // Update is called once per frame     void Update()     {         //LeftRotation
        if (StageRotation.LeftRotateFlag)
        {
            //  用 slerp 进行插值平滑的旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, currentPlayerTargetAngels, playerRotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(currentPlayerTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = currentPlayerTargetAngels;        //旋转到目标角度     
            }       
        }
        //RightRotation
        else if (StageRotation.RightRotateFlag)
        {
            //  用 slerp 进行插值平滑的旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, currentPlayerTargetAngels, playerRotateSpeed * Time.deltaTime);
            // 当初始角度跟目标角度小于1,将目标角度赋值给初始角度,让旋转角度是我们需要的角度
            if (Quaternion.Angle(currentPlayerTargetAngels, transform.rotation) < 1)
            {
                transform.rotation = currentPlayerTargetAngels;        //旋转到目标角度     
            }
        }     }     void FixedUpdate()     {                  if (StageRotation.MoveFlag == true)         {             //Move             float H = Input.GetAxis("LeftStickHorizontal");             float V = Input.GetAxis("LeftStickVertical");             if (H != 0 || V != 0)             {                 transform.Translate(new Vector3(H, 0, 0) * Time.deltaTime * moveSpeed, Space.World);             }             else             {                 //没有移动             }             //Jump             if (FootCollision.grounded == true)             {                 //ADownButton                 if (Input.GetButton("ADownButton"))                 {                     print("ADownButton");                     playerRigidbody.AddForce(new Vector3(0f, jumpForce, 0f));                     FootCollision.grounded = false;                 }              }                       }             }     ////碰撞检测Stay
    //private void OnCollisionStay(Collision collision)     //{     //    if (collision.collider.tag == "ground")     //    {     //        grounded = true;     //    }     //}
    ////碰撞检测Exit
    //private void OnCollisionExit(Collision collision)     //{     //    if (collision.collider.tag == "ground")     //    {     //        grounded = false;     //    }     //} } 