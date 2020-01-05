using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    
using System.Collections;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour {

    public enum state
    {
        start, notComplete, complete
    }

    public state _state;

    [Header("對話")]
    public string sayStart = "";
    public string sayNotComplete = "";
    public string sayComplete = "";
    [Range(0.001f, 1.5f)]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到物件為"player"
        if (collision.name == "player")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
            SayClose();
    }

    private void Say()
    {
        // 畫布.顯示
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;


        // 判斷式(狀態)
        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(sayStart));           // 開始對話
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));     // 開始對話未完成
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));        // 開始對話
                
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              // 清空文字

        for (int i = 0; i < say.Length; i++)            // 迴圈跑對話.長度
        {
            textSay.text += say[i].ToString();          // 累加每個文字
            yield return new WaitForSeconds(speed);     // 等待
        }
    }


    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    public void PlayerGet()
    {
        countPlayer++;
    }

}
