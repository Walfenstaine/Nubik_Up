using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class GameInterfase : MonoBehaviour
{
    public Data data;
    public Text record, upp;
    [SerializeField] private Language up;
    [SerializeField] private Language rec;

    void Update()
    {
        if (Muwer.rid != null)
        {
            int pos = ((int)Muwer.rid.transform.position.y - 1) + data.up;
            if (Bridge.platform.language == "ru")
            {
                record.text = rec.ru + ": " + (data.record);
                upp.text = up.ru + ": " + pos;
            }
            else
            {
                upp.text = up.en + ": " + pos;
                record.text = rec.en + ": " + (data.record);

            }

            if (pos > data.record)
            {
                data.record = pos;
            }
        }
    }
}
