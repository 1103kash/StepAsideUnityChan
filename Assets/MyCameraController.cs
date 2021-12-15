using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクトを取得するための変数を用意
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //スタート時点でのUnityちゃんとカメラの位置(z)の差を求めて変数に入れる
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置との差に合わせてカメラ位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
