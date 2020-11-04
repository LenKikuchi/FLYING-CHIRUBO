using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject Chirubo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ちるぼうの位置情報を格納する
        Vector3 chiruboPosition = Chirubo.transform.position;

        //背景の位置情報を格納する
        Vector3 backPosition = transform.position;

        //ちるぼうと背景の位置を格納する
        Vector3 distance = chiruboPosition - backPosition;

        //距離が6以上離れた場合
        if (distance.x >= 6)
        {
            //背景の位置をちるぼうの位置と同じにする
            transform.position = new Vector3(chiruboPosition.x, 0, 0);
        }
    }
}
