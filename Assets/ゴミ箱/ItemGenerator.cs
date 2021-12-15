using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
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
        //一定の距離(15m)ごとにアイテムを生成(for文の条件の変数をそのままz軸に流用できるようにしている)
        for(int i = startPos; i < goalPos; i += 15)
        {
            //設置するオブジェクトを確率で決定(20%コーン80%車orコイン)
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸=横方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiateのままだとランダムに配置されるため、一度GameObject型の変数に入れて取得してから、座標を指定してあげる
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //コインもしくは車をレーン毎に生成
                for(int j = -1; j <= 1; j++)
                {
                    //オブジェクトを設置するz座標ずらす用の変数
                    int offsetZ = Random.Range(-5, 6);
                    //設置するオブジェクトを確率で決定
                    int item = Random.Range(1, 11);
                    //60%コイン30%車10%何もなし
                    if(1 <= item && item <= 6)
                    {
                        //コインを生成(コインが真横並びだと取りずらいためoffsetで前後5m以内のずれを設定
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7<= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
