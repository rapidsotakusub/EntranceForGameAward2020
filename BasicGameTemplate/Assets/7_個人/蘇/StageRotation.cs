using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotation : MonoBehaviour
{
    //public Space m_RotateSpace;
    //public float m_RotateSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Rotate(Vector3.up * m_RotateSpeed * Time.deltaTime, m_RotateSpace);

        //do something
        //GetAxis(全部で７Axis)
        float LeftStickHorizontal = Input.GetAxis("LeftStickHorizontal");
        float LeftStickVertical = Input.GetAxis("LeftStickVertical");
        float LeftCrossHorizontal = Input.GetAxis("LeftCrossHorizontal");
        float LeftCrossVertical = Input.GetAxis("LeftCrossVertical");
        float RightStickHorizontal = Input.GetAxis("RightStickHorizontal");
        float RightStickVertical = Input.GetAxis("RightStickVertical");
        float LRTrigger = Input.GetAxis("LRTrigger");

        //左スティック
        if (Mathf.Abs(LeftStickHorizontal) > 0.05f || Mathf.Abs(LeftStickVertical) > 0.05f)
        {
            print("LeftStickHorizontal:" + LeftStickHorizontal);
            print("LeftStickVertical:" + LeftStickVertical);
        }
        //十字キー
        if (Mathf.Abs(LeftCrossHorizontal) > 0.05f || Mathf.Abs(LeftCrossVertical) > 0.05f)
        {
            print("LeftCrossHorizontal:" + LeftCrossHorizontal);
            print("LeftCrossVertical:" + LeftCrossVertical);
        }
        //右スティック
        if (Mathf.Abs(RightStickHorizontal) > 0.05f || Mathf.Abs(RightStickVertical) > 0.05f)
        {
            print("RightStickHorizontal:" + RightStickHorizontal);
            print("RightStickVertical:" + RightStickVertical);
        }
        //LRTrigger
        if (Mathf.Abs(LRTrigger) > 0.05f)
        {
            print("LRTrigger:" + LRTrigger);
        }
        ////////////////////////////
        //GetButton
        //ViewButton
        if (Input.GetButtonDown("ViewButton"))
        {
            print("ViewButton");
        }
        //MenuButton
        if (Input.GetButtonDown("MenuButton"))
        {
            print("MenuButton");
        }
        //ADownButton
        if (Input.GetButtonDown("ADownButton"))
        {
            print("ADownButton");
        }
        //BRightButton
        if (Input.GetButtonDown("BRightButton"))
        {
            print("BRightButton");
        }
        //XLeftButton
        if (Input.GetButtonDown("XLeftButton"))
        {
            print("XLeftButton");
        }
        //YUpButton
        if (Input.GetButtonDown("YUpButton"))
        {
            print("YUpButton");
        }
        //LButton
        if (Input.GetButtonDown("LButton"))
        {
            transform.Rotate(0, 0, 90);
            print("LButton");
        }
        //RButton
        if (Input.GetButtonDown("RButton"))
        {
            transform.Rotate(0, 0, -90);
            print("RButton");
        }
        //LeftStickDown
        if (Input.GetButtonDown("LeftStickDown"))
        {
            print("LeftStickDown");
        }
        //RightStickDown
        if (Input.GetButtonDown("RightStickDown"))
        {
            print("RightStickDown");
        }
    }
}
