using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChiruboManager : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 0.02f;

    //ゲームオーバーキャンバスを格納する変数
    public GameObject GameOver;

    //スコアオブジェクトを格納する変数
    public GameObject ScoreText;

    //BGMマネージャーを取得する変数
    public GameObject BgmManager;

    public Collision2D collision;

    //スコア
    int score;

    //クリアになるアイテム数
    int ClearNumber = 10;

    //効果音
    public AudioClip item;
    public AudioClip GameOverSounds;

    //オーディオソースを格納する変数
    AudioSource audioSource;

    //BGMのオーディオソースを格納する変数
    AudioSource BgmSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        BgmSource = BgmManager.GetComponent<AudioSource>();
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

    // 画面外に出た時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //効果音を出す
        audioSource.PlayOneShot(GameOverSounds);

        //Bgmを止める
        BgmSource.Stop();

        //ゲームオーバーキャンバスを出す
        GameOver.SetActive(true);

        //ちるぼうを停止
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

        //前進を停止
        speed = 0f;
    }

    //すれ違った時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //桜とすれ違った時
        if (collision.gameObject.tag == "sakura")
        {
            //効果音を出す
            audioSource.PlayOneShot(item);

            //桜を消す
            Destroy(collision.gameObject);

            //スコアを加算
            GetScore();

            if(score == ClearNumber)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }

        //雷とすれ違った時
        if (collision.gameObject.tag == "kaminari")
        {
            //効果音を出す
            audioSource.PlayOneShot(GameOverSounds);

            //BGMを止める
            BgmSource.Stop();

            //ゲームオーバーキャンバスを表示
            GameOver.SetActive(true);

            //ちるぼうを停止
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            //前進を停止
            speed = 0f;
        }
    }

    //スコアを加算する関数
    void GetScore()
    {
        score++;

        //スコアを表示
        ScoreText.GetComponent<Text>().text = "SCORE:" + score.ToString();

    }

    //スコアをリセットする関数
    void ReserScore()
    {
        ScoreText.GetComponent<Text>().text = "SCORE:0";
    }

    // リトライボタンを押したときにゲームをリスタートさせる
    public void OnRetry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
