using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacctorCamera : MonoBehaviour {
    [SerializeField] private Vector2 mousePosition;
    public float topPoint;
    public float leftPoint;
    public float bottomPoint;
    public float rightPoint;
    public static Vector3 vec;
    public static float moveSpeed = 4.0F;
    public GameObject Charactor;
 

    //   // Use this for initialization
    void Start () {
        vec = Vector3.zero;
        SetInitialpoint();
        leftPoint = 0;
        bottomPoint =0;
        topPoint = Screen.height;
        rightPoint = Screen.width;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * 10;
        CameraMove();
        mousePosition = Input.mousePosition;
        CheckCanvasMousePosition();
    }
    /*カメラの移動方向*/
    void CameraMove()
    {
        
        if (Input.GetKey(KeyCode.W)) vec.z += 1;       
        if (Input.GetKey(KeyCode.S)) vec.z -= 1;      
        if (Input.GetKey(KeyCode.A)) vec.x -= 1;
        if (Input.GetKey(KeyCode.D)) vec.x += 1;
        TransPos(vec);
    }
    /*カメラ移動処理　4.0F = 速度　*/
    private void TransPos(Vector3 vec)
    {
        transform.position += vec.normalized * moveSpeed * Time.deltaTime;
    }
    void CheckCanvasMousePosition()
    {
        if (mousePosition.x <= leftPoint)
        {
            CharacctorCamera.vec.x -= 1;
            CharacctorCamera.moveSpeed = 20.6F;
        }
        else if (mousePosition.x >= rightPoint)
        {
            CharacctorCamera.vec.x += 1;
            CharacctorCamera.moveSpeed = 20.6F;
        }
        else if (mousePosition.y <= bottomPoint)
        {
            CharacctorCamera.vec.z -= 1;
            CharacctorCamera.moveSpeed = 20.6F;
        }
        else if (mousePosition.y >= topPoint)
        {
            CharacctorCamera.vec.z += 1;
            CharacctorCamera.moveSpeed = 20.6F;
        }
        else
        {
            CharacctorCamera.vec = Vector3.zero;
            CharacctorCamera.moveSpeed = 4.0F;
        }

    }

    private void SetInitialpoint()
    {
        transform.position = Charactor.transform.position;
        vec.y += 53;
        transform.position += vec;
    }
}
