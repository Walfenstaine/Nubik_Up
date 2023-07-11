using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;
public class ChekMenue : MonoBehaviour
{
    public ShowInter si;
    public GameObject start, reklama;
    [SerializeField] private Language recTimer;
    public Text timer;
    private float tim;
    private bool ac;

    void Start()
    {
        tim = 3;
        ac = true;
    }

    void Update()
    {
        if (tim > 0)
        {
            tim -= Time.unscaledDeltaTime;
            start.SetActive(false);
            reklama.SetActive(true);
            if (Bridge.platform.language == "ru")
            {
                timer.text = recTimer.ru + " " + ((int)tim);
            }
            else
            {
                timer.text = recTimer.en + " " + ((int)tim);
            }
        }
        else
        {
            start.SetActive(true);
            reklama.SetActive(false);
            tim = 0;
            timer.text = "";
            if (ac)
            {
                si.ShowADS();
                ac = false;
            }
        }
    }
}
