using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2ItemGenerator : MonoBehaviour
{
    // 各Prefebを入れる変数を準備(Publicで宣言してInspectorから代入)
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向(横)の範囲:-3.4が左レーン中央で3.4が右レーン中央
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Unityちゃんが通過した際に50m先にオブジェクトを生成
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "UnityTag")
        {
            //設置するオブジェクトを確率で決定(20％コーン80％車orコイン)
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //コーンをx軸=横方向に一直線に生成
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiateのままだとランダムに配置されるため、一度GameObject型の変数に入れて取得してから、座標を指定
                    //Z軸については、このスクリプトがアタッチされるトリガー用オブジェクトから50m先地点を指定
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.gameObject.transform.position.z + 50);
                }
            }
            else
            {
                //車orコインをレーン毎に生成
                for (int j = -1;j <= 1; j++)
                {
                    //オブジェクトを設置するz座標を前後にずらすための変数
                    int offsetZ = Random.Range(-5, 6);
                    //車orコインを確率で決定
                    int item = Random.Range(1, 11);
                    //60％コイン30％車10％何もなし
                    if(1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.gameObject.transform.position.z + 50 + offsetZ);
                    }
                    else if(7<=item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.gameObject.transform.position.z + 50 + offsetZ);
                    }
                }
            }
        }
    }
}
