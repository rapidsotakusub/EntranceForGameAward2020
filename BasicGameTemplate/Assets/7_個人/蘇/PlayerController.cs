using System.Collections; using System.Collections.Generic; using UnityEngine;  public class PlayerController : MonoBehaviour {     public static bool grounded;        //地面当たかどうかのFlag     public float moveSpeed = 5f;        //Player移動スピード     public Rigidbody playerRigidbody;     public float jumpForce = 50.0f;     public static Quaternion currentPlayerTargetAngels;
    public static Quaternion oldPlayerTargetAngels;     public float playerRotateSpeed = 2f;                ////     //RaycastHit hitinfo;         //当たったオブジェクトの情報格納
    //float distance;             //rayの発射距
    //Ray ray;      ////Test     //private Rigidbody2D myRigidbody2D;      // Start is called before the first frame update     void Start()     {         grounded = true;        //地面フラグ         // Quaternion.Slerp()第二个参数需要的是四元数,所以这里需要将目标的角度转成四元数去计算
        oldPlayerTargetAngels = Quaternion.Euler(0, 0, 0f);
        currentPlayerTargetAngels = Quaternion.Euler(0, 90f, 0);

        ////Ray
        //ray.direction = new Vector3(0, -1, 0);          //向き
        //distance = 0.6f;          ////Test         //myRigidbody2D = GetComponent<Rigidbody2D>();     }      // Update is called once per frame     void Update()     {
        ////Test         ////角色是否在地面
        //Debug.DrawRay(transform.position, Vector2.down * 0.11f, Color.red);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.15f, 1 << 8);
        //if (hit.collider != null)
        //{
        //    grounded = true;
        //}
        //else
        //{
        //    grounded = false;
        //}
         //ステーシが回転の時、プレーヤー自身が逆に回転します         //LeftRotation
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
        }

        //地面当たり判定の判断
        //    if (collision.collider.tag == "ground")
        //    {
        //        grounded = true;
        //    }

        
        //else
        //{
        //    grounded = false;
        //}
    }     void FixedUpdate()     {         ////rayの場所と方向
        //ray.origin = this.transform.position;           //開始地点         //ray.direction = new Vector3(0, -1, 0);          //向き         //if (Physics.Raycast(ray, out hitinfo, distance))
        //{
        //    grounded = true;
        //    Debug.Log(hitinfo.collider.gameObject.transform.position);

        //    Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 5);
        //}         //ray.origin = this.transform.position;           //開始地点         //ray.direction = new Vector3(0, -1, 0);          //向き           if (StageRotation.MoveFlag == true)         {             //Move             float H = Input.GetAxis("LeftStickHorizontal");             float V = Input.GetAxis("LeftStickVertical");             if (H != 0 || V != 0)             {                 transform.Translate(new Vector3(H, 0, 0) * Time.deltaTime * moveSpeed, Space.World);             }             else             {                 //没有移动             }             //Jump             if (grounded == true)             {                 //ADownButton                 if (Input.GetButtonDown("ADownButton"))                 {                     print("ADownButton");                     playerRigidbody.AddForce(new Vector3(0f, jumpForce, 0f));                     grounded = false;                 }              }                       }             }     //碰撞检测Stay
    private void OnBoxCollisionStay(Collision collision)     {         if (collision.collider.tag == "ground")         {             grounded = true;         }     }
    //碰撞检测Exit
    private void OnBoxCollisionExit(Collision collision)     {         if (collision.collider.tag == "ground")         {             grounded = false;         }     } } 