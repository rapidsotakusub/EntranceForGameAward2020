using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    private int rotangle;
    private int rotateFrame;
    private bool RrotFg;
    private bool LrotFg;
    // 変数
    private int frameCount;
    private float prevTime;
    private float fps;

    public GameObject rotateobject;
    public GameObject FixedBlock;
    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.R))
        {
            if (RrotFg == false)
            {
                RrotFg = true;
                rotangle = -90;
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (LrotFg == false)
            {
                LrotFg = true;
                rotangle = 90;
            }
        }


        if (RrotFg == true)
        {
            prevTime += Time.deltaTime;
            if (prevTime >= 0.03f)
            {
                if (rotangle != 0)
                {
                    rotate();
                }
                else
                {
                    RrotFg = false;
                }
                prevTime = 0.0f;
            }
        }

        if (LrotFg == true)
        {
            prevTime += Time.deltaTime;
            if (prevTime >= 0.03f)
            {
                if (rotangle != 0)
                {
                    rotate();
                }
                else
                {
                    LrotFg = false;
                }
                prevTime = 0.0f;
            }
        }
    }


    void rotate()                                              //1度回転
    {
        if (RrotFg == true)
        {
            rotateobject.transform.Rotate(new Vector3(0, 0, -1));
            rotangle++;
        }
        if (LrotFg == true)
        {
            rotateobject.transform.Rotate(new Vector3(0, 0, 1));
            rotangle--;
        }


        }

}