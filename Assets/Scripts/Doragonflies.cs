using UnityEngine;
using System.Collections;
using System;

public class Doragonflies : MonoBehaviour
{
    float sideAngle;
//    float varticalAngle;
    float timecounter;
    float span;
    float nowTime;
    float splitTime;
    float speed;
    float hover;
    bool idou;
    static bool first;
    public static bool Flag
    {
        set { first = value; }
        get { return first; }
    }
    Vector3 player;
    UIManager uim;


    // Use this for initialization
    void Start()
    {
        uim = UIManager.getInstance;
        player = GameObject.Find("[CameraRig]").transform.FindChild("Camera (head)").position;
        if (!gameObject.ToString().Equals("Tombo"))
        {
            Vector3 point = UnityEngine.Random.insideUnitSphere*15.0f;
            point.y = Math.Abs(point.y) * 0.85f;
            point.y = point.y - 4.2f;
            transform.Translate(point, Space.World);
            transform.Rotate(0.0f, 0.0f ,360.0f * UnityEngine.Random.value, Space.Self);
            GetComponent<MeshRenderer>().enabled = true;
        }

        splitTime = Time.time;
        span = UnityEngine.Random.value * 7.0f;
        speed = 3.0f + 2.0f * UnityEngine.Random.value;
        hover = -0.2f + UnityEngine.Random.value;
        idou = true;
        gameObject.SetActive(true);
        
        // 自分の位置を決定
    }

    // Update is called once per frame
    void Update()
    {
        if (first && uim.SceneChangeListener == 1)
        {
            AI();
        }else if(uim.SceneChangeListener == 2)
        {
            Destroy(gameObject);
        }
    }

    void AI()
    {
        nowTime = Time.time;
        timecounter = nowTime - splitTime;
        if (span < timecounter)
        {
            // 時間処理の変更
            splitTime = nowTime;

            // 次の行動が移動であれば乱数の決定
            // 停止であれば停止時間を決めてbool idouをfalseに
            if (UnityEngine.Random.value < 0.4)
            {
                // 停止の場合
                idou = false;
                span = UnityEngine.Random.value * 1.5f;
                return;
            }
            idou = true;

            // 乱数で次の動きを決定する

            float split = Math.Abs(transform.position.sqrMagnitude - player.sqrMagnitude); // プレイヤーの位置と自分の位置の距離の差の2乗

            // 大本の数字
            sideAngle = UnityEngine.Random.Range(-180.0f, 1800.0f);
            //varticalAngle = UnityEngine.Random.Range(-0.2f, 0.2f);
            span = UnityEngine.Random.value * 5.0f; // 移動時間

            float angle = 0.0f;
            if (split > 7)
            {
                // 離れすぎてるので近づくように
                Vector3 forMe = player - transform.position;
                angle = Vector3.Angle(transform.forward, forMe) * UnityEngine.Random.value;
            }
            else if (split < 1)
            {
                // 近すぎるので離れるように
                Vector3 forMe = player - transform.position;
                angle = 180 - Vector3.Angle(transform.forward, forMe) * UnityEngine.Random.value;
            }

            // 回転は乱数決定後に実行
            transform.Rotate(0.0f, 0.0f, sideAngle + angle, Space.Self);
        }
        else
        {
            float speed;
            if (idou)
            {
                // 移動中
                speed = Time.deltaTime * this.speed;
            }
            else
            {
                // ホバリング中
                speed = Time.deltaTime * this.hover;
            }
            transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * speed, Space.Self);
        }
    }

    public void setFirst(bool flag)
    {
        first = flag;
    }

}
