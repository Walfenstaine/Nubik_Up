using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using InstantGamesBridge;

public class Interface : MonoBehaviour
{
    public bool fli;
    public Scrollbar sense;
    public Data data;
    public UnityEvent gameer, menue, chekPoint, down, andlevel;
    public static Interface rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    void Start()
    {
        Menu();
    }

    public void Menu()
    {
        sense.value = data.sense;
        menue.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }
    public void ChekPoint()
    {
        Muwer.rid.controller.enabled = false;
        chekPoint.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }

    public void Down()
    {
        if (fli)
        {
            Muwer.rid.controller.enabled = false;
            down.Invoke();
            Time.timeScale = 0;
            Lock(false);
        }
    }

    public void Game()
    {
        fli = false;
        Muwer.rid.sensitivity = sense.value;
        Muwer.rid.controller.enabled = true;
        gameer.Invoke();
        Time.timeScale = 1;
        Lock(true);
        data.sense = sense.value;
        
    }
    public void Andlevel()
    {
        andlevel.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }

    void Lock(bool stateTemp)
    {
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        if (stateTemp && (Bridge.device.type == InstantGamesBridge.Modules.Device.DeviceType.Desktop))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
