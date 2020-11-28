using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{ 
    //桜プレハブを格納するための変数
    public GameObject SakuraPrefab;

    //雷プレハブを格納するための変数
    public GameObject KaminariPrefab;

    //ちるぼうを格納するための変数
    public GameObject Chirubo;

    // Start is called before the first frame update
    void Start()
    {
        //生成する
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成する関数
    void Generate()
    {
        //ちるぼうの場所
        Vector3 chiruboPos = Chirubo.transform.position;

        //乱数を作る
        float random = Random.Range(-3.0f, 3.0f);

        //生成する場所
        Vector3 generatePos = new Vector3(chiruboPos.x + 5.0f, random, 0);

        //確率を表すため使う変数
        float probability = Random.Range(1.0f, 100.0f);

        //一定の確率で雷を生成
        if(probability <= 30)
        {
            //雷を作成する
            Instantiate(KaminariPrefab, generatePos, Quaternion.identity);
        }
        else
        {
            //桜を作成する
            Instantiate(SakuraPrefab, generatePos, Quaternion.identity);
        }
     

        //無限に生成
        Invoke("Generate", 2.0f);
    }
}
