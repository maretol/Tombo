using UnityEngine;
using System;
using System.Collections;
using System.Threading;

public class GameStart : MonoBehaviour
{
    Transform ContTrans;
    Vector3 ContPos;
    const string cont = "Controller (right)";
    GameObject katonbo;
    UIManager uim;
    // Use this for initialization
    void Start()
    {
        ContTrans = GameObject.Find("[CameraRig]").transform.FindChild(cont).transform;
        katonbo = GameObject.Find("Tombo");
        uim = UIManager.getInstance;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateEnemy()
    {
        Instantiate(katonbo);
    }

    void OnTriggerEnter(Collider obj)
    {
        // ここでゲーム開始
        uim.SceneChangeListener = 1;
        ContTrans.FindChild("虫網").gameObject.SetActive(true);
        Destroy(gameObject);
        Doragonflies.Flag = true;
        for (int i = 0; i < 20; i++)
        {
            GenerateEnemy();
        }
    }
}
