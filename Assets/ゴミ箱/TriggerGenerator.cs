using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGenerator : MonoBehaviour
{
    // オブジェクト生成トリガーのPrefabを入れる変数を準備
    public GameObject gentriggerPrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト生成トリガーを、生成を行いたいZ軸の各地点から-50の各地点に配置
        for (int i = startPos; i <goalPos; i += 15)
        {
            GameObject gentrigger = Instantiate(gentriggerPrefab);
            gentrigger.transform.position = new Vector3(gentrigger.transform.position.x, gentrigger.transform.position.y, i - 50);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
