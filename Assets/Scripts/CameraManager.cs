using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Chirubo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //位置情報を格納
        Vector3 chiruboPosition = Chirubo.transform.position;

        //カメラとちるぼうの位置を同じにする
        transform.position = new Vector3(chiruboPosition.x, 0, -10.0f);
    }
}
