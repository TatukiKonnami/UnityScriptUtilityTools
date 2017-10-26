using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacctorCamera : MonoBehaviour {

    [SerializeField] private Vector2 mousePosition;
    public static Vector3 vec;
    public static float moveSpeed = 4.0F;

    void Start () {
        vec = Vector3.zero;
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
        if (mousePosition.x <= 250)
        {
            CharacctorCamera.vec.x -= 1;
            CharacctorCamera.moveSpeed = 10.6F;
        }
        else if (mousePosition.x >= 1690)
        {
            CharacctorCamera.vec.x += 1;
            CharacctorCamera.moveSpeed = 10.6F;
        }
        else if (mousePosition.y <= 130)
        {
            CharacctorCamera.vec.z -= 1;
            CharacctorCamera.moveSpeed = 10.6F;
        }
        else if (mousePosition.y >= 960)
        {
            CharacctorCamera.vec.z += 1;
            CharacctorCamera.moveSpeed = 10.6F;
        }
        else
        {
            CharacctorCamera.vec = Vector3.zero;
            CharacctorCamera.moveSpeed = 4.0F;
        }
    }
}
