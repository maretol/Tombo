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

        float margine = Vector3.Distance(ContTrans.position,transform.position);
        
        if(margine < 0.2)
        {
            // ここでゲーム開始
            uim.SceneChangeListener = 1;
            ContTrans.FindChild("虫網").gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
            Doragonflies.Flag = true;
            for(int i=0; i<15; i++)
            {
                GenerateEnemy();
            }        
        }
    }

    void GenerateEnemy()
    {
        Instantiate(katonbo);
    }
}
