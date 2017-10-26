using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacctorCamera : MonoBehaviour {
    /*
     * 神様視点のゲームで使えそうなカメラ用スクリプト
     * 
     * 使い方:
     *      Charactorに真ん中に置きたいオブジェクトを追加
     *      WASDキーでカメラが移動
     *      画面端にマウスが行くとそちらにカメラが移動
     *      Space キーで中心のオブジェクトが見える位置に移動
     *      
     * 
     * 作成者の悲しみ：
     *      割とUnity触り始めて二日間くらいな感じで作ったスクリプト故汚いので定石を誰か教えて
     *      というかプルリクください
     * 
     */



    /* 現在のマウスのある位置　テスト用に外からいじれる */
    [SerializeField] private Vector2 mousePosition;

    /* 画面端の4点の座標(topとbottomはy座標,leftとrightはx座標のみ) */
    public float topPoint;
    public float leftPoint;
    public float bottomPoint;
    public float rightPoint;

    /* 距離移動させるためのVector3型変数 */
    public static Vector3 vec;
    
    /* カメラの移動速度（デフォルト4.0F） */
    public static float moveSpeed = 4.0F;

    /* カメラが追従するキャラクターをアタッチする場所 */
    public GameObject Charactor;
 

   // Use this for initialization
    void Start () {        
        vec = Vector3.zero;
        SetInitialpoint();
        MonitorDefine();
        

    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * 10;
        CameraMove();
        mousePosition = Input.mousePosition;
        CheckCanvasMousePosition();
        SetDefaultPositon();
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

    /* マウスが画面端に来たら移動する */
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

    /* カメラを初期位置に配置する */
    private void SetInitialpoint()
    {
        transform.position = Charactor.transform.position;
        vec.y += 53;
        transform.position += vec;
    }

    /* モニタの四隅の点をセットする */
    private void MonitorDefine()
    {
        leftPoint = 0;
        bottomPoint = 0;
        topPoint = Screen.height;
        rightPoint = Screen.width;
    }

    /* スペースキーを押したら初期位置へ */
    private void SetDefaultPositon()
    {
        if (Input.GetKey(KeyCode.Space)) SetInitialpoint();
    }
}
