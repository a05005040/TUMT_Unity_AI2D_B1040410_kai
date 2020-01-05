using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API


namespace KAI
{
    public class GameManager : MonoBehaviour
    {

        public void Replay()
        {
            //Application.LoadLevel("場景名稱");    // 舊版 API
            SceneManager.LoadScene("8787");   // 新版 API
        }

        public void Quit()
        {
            Application.Quit(); // 應用程式.離開遊戲
        }

    }

}
