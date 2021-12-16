using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ver2ItemGenerator : MonoBehaviour
{
    //各Prefabを入れる変数を準備(Publicで宣言してInspectorから代入)
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    //オブジェクトを生成するx方向(横)の範囲:-3.4が左レーン中央、3.4が右レーン中央
    private float posRange = 3.4f;
    //オブジェクト生成する地点(前=Z方向)
    private float unity2obj = 50;
    //生成タイミング計測用の変数(オブジェクト生成時のZ座標を入れる)
    private float pointA;

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始時に即座に1回生成するために代入
        this.pointA = -15;
    }

    // Update is called once per frame
    void Update()
    {
        //前回オブジェクト生成時のZ座標から15離れたタイミングで生成
        if(transform.position.z - this.pointA >= 15)
        {
            //生成時のZ座標を登録
            this.pointA = transform.position.z;
            //設置するオブジェクトを確率で決定(20%コーン80%車orコイン)
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸=横方向に一直線に生成
                for(float j = -1;j <= 1; j += 0.4f)
                {
                    //Instantiateのままだとランダム配置のため、GameObject型の変数に入れて取得してから、座標を指定
                    //z座標は、現在のUnityちゃんの座標からunity2objに入れた値分離れた場所に生成
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.gameObject.transform.position.z + unity2obj);
                }
            }
            else
            {
                //コインもしくは車をレーン毎に生成
                for(int j = -1; j<= 1; j++)
                {
                    //オブジェクトを設置する際にZ座標をずらす用の変数
                    int offsetZ = Random.Range(-5, 6);
                    //設置するオブジェクトを確率で決定
                    int item = Random.Range(1, 11);
                    //60%コイン 30%車 10％何もなし
                    if(1<=item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.gameObject.transform.position.z + unity2obj + offsetZ);
                    }
                    else if(7<= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.gameObject.transform.position.z + unity2obj + offsetZ);
                    }
                }
            }
        }
    }
}
