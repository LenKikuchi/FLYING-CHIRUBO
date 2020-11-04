using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //ボタンを押した時に呼び出される関数
    void PushButton()
    {
        //画面遷移の処理
        SceneManager.LoadScene("GameSceneß");
    }
}
