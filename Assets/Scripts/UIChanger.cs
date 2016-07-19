using UnityEngine;
using System.Collections;

public class UIChanger : MonoBehaviour {
    TextMesh local;
    UIManager uim;
    bool first;
    // Use this for initialization
	void Start () {
        local = GetComponent<TextMesh>();
        local.text = "トンボを捕まえよう！！！！！\n\nStartボックスを叩いてスタート！！";
        local.alignment = TextAlignment.Center;
        local.fontSize = 16;

        uim = UIManager.getInstance;
        first = true;
	}
	
	// Update is called once per frame
	void Update () {
        switch (uim.SceneChangeListener)
        { 
            case 0:
                // 開始前
                break;
            case 1:
                if (first)
                {
                    uim.setTime();
                    first = false;
                }
                // ゲーム中
                if (uim.getRawCountTime < 0)
                {
                    uim.SceneChangeListener = 2;
                    break;
                }
                local.fontSize = 12;
                local.text = "残り時間 : " +uim.getCountTime() + "秒";
                break;
            case 2:
                // リザルト画面
                local.fontSize = 16;
                local.text = "スコア : " + uim.Catcher + " 匹\n";
                local.text += "トリガーを引いてもう一度！";
                first = true;
                break;
        }
	}
}
