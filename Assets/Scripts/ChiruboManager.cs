using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChiruboManager : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 0.02f;

    //ゲームオーバーキャンバスを格納する変数
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //前進させる
        transform.position += new Vector3(speed, 0, 0);

        //タップしたときの記述
        if (Input.GetMouseButton(0))
        {
            //上向きの力を加える 引数にはx軸,y軸がそれぞれ格納される
            rb.velocity = new Vector2(0.0f, 5.0f);
        }
    }

    // ぶつかった時の処理
    private void OnColliseionExit2D(Collision2D collision)
    {
        //ゲームオーバーキャンバスを出す
        
    }

    // リトライボタンを押したときにゲームをリスタートさせる
    public void OnRetry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
