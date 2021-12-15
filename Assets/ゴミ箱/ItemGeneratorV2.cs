using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorV2 : MonoBehaviour
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
    //Unityちゃんのオブジェクトを取得するための変数を用意
    private GameObject unitychan;
    //Unityちゃんから見て前方向(Z軸方向)50m先
    private float fiftyMahead;
    
    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんから見て50m先のZ軸を計算
        this.fiftyMahead = this.unitychan.transform.position.z + 50;
        //Unityちゃんから見て50m先が、Z:80の時 or 80から数えて15の倍数の時(ただし80-360の範囲)にオブジェクトを生成
        if(this.fiftyMahead == 80 || ((this.fiftyMahead - 80) % 15 == 0 && 80 <= this.fiftyMahead && this.fiftyMahead <= 360))
        if(Mathf.Approximately(float.Parse(this.fiftyMahead.ToString("f2")), 80.0f) || (Mathf.Approximately(float.Parse(this.fiftyMahead.ToString("f2")) % 15 , 0.0f) && 80 <= this.fiftyMahead && this.fiftyMahead <= 360))
        {
            //以降、Lesson6のStart関数で一括で生成する際と同様(生成Z軸を50m先地点に変更したのみ)
            //設置するオブジェクトを確率で設定(20％コーン80％車orコイン)
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //コーンをx軸=横方向に一直線に生成
                for(float j = -1; j<=1;j += 0.4f)
                {
                    //Instantiateのままだとランダム配置のため、一度GameObject型の変数に入れて取得してから座標を指定
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, fiftyMahead);
                }
            }
            else
            {
                //コインもしくは車をレーン毎に生成
                for(int j = -1;j <= 1; j++)
                {
                    //オブジェクトを設置する際にZ座標を前後にずらす為の変数
                    int offsetZ = Random.Range(-5, 6);
                    //設置するオブジェクトを確率で決定
                    int item = Random.Range(1, 11);
                    //60％コイン30％車10％何もなし
                    if(1 <= item && item <= 6)
                    {
                        //コインを生成(コインが真横並びだと取りずらいためoffsetで前後5m以内のずれを設定
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, fiftyMahead + offsetZ);
                    }
                    else if (7<= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, fiftyMahead + offsetZ);
                    }
                }
            }
        }
    }
}
