using UnityEngine;
using System.Collections;

public class CatchDragonfly : MonoBehaviour {
    UIManager uim;

	// Use this for initialization
	void Start () {
        uim = UIManager.getInstance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // トンボとぶつかった時の反応。捕獲処理
    void OnTriggerEnter(Collider obj)
    {
        if (uim.SceneChangeListener == 1)
        {
            Instantiate(GameObject.Find("Tombo"));
            Destroy(obj.gameObject);
            uim.Catcher = 1;
        }
    }
}
