using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReStarter : MonoBehaviour {
    UIManager uim;
    SteamVR_TrackedObject controller;
    SteamVR_Controller.Device device;
    Transform cont;

    Vector2 lastPoint;
    Vector2 point;
    int lastScore, score;
	// Use this for initialization
	void Start () {
        uim = UIManager.getInstance;
        controller = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)controller.index);
        cont = GameObject.Find("[CameraRig]").transform.FindChild("Controller (right)").FindChild("虫網");
        point = lastPoint = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
        if (uim.SceneChangeListener == 1)
        {
            // ここがゲーム中
            score = uim.Catcher;
            if (lastScore != score)
            {
                device.TriggerHapticPulse(2000);
            }
            lastScore = score;

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (device.GetAxis().y > 0.3)
                {
                    cont.Translate(3.0f, 0.0f, 0.0f, Space.Self);
                }
                else if (device.GetAxis().y < -0.3)
                {
                    cont.Translate(-3.0f, 0.0f, 0.0f, Space.Self);
                }
            }

        }
        else if (uim.SceneChangeListener == 2)
        {
            //　ゲーム終了
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                // Restart
                uim.SceneChangeListener = 0;
                uim.Restart();
                SceneManager.LoadScene(0);
            }
        }
	}
}
