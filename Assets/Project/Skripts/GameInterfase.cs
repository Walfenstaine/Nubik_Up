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
        if (Bridge.platform.language == "ru")
        {
            record.text = rec.ru + ": " + (data.record);
            upp.text = up.ru + ": " + ((int)Muwer.rid.transform.position.y - 1);
        }
        else
        {
            record.text = rec.en + ": " + (data.record);
            upp.text = up.en + ": " + ((int)Muwer.rid.transform.position.y - 1);
        }
        
        if (((int)Muwer.rid.transform.position.y - 1) > data.record)
        {
            data.record = ((int)Muwer.rid.transform.position.y - 1);
        }
    }
}
