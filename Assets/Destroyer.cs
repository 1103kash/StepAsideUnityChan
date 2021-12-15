using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //Unityちゃんのオブジェクトを取得する変数を用意
    private GameObject Unitychan;
    //Unityちゃんとの距離を入れる変数を用意
    private float distanceUni2Me;
    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.Unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんとオブジェクトの間の距離を図る
        this.distanceUni2Me = Unitychan.transform.position.z - this.transform.position.z;
        //画面から見切れたら(Unityちゃんから見てZ軸方向=後ろに8.0f離れたら)Destroyで自身を破棄
        if(this.distanceUni2Me >= 8.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
