using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Andlevel : MonoBehaviour
{
    public string lvl;
    public Data data;
    public void Reload()
    {
        SaveAndLoad.Instance.Save();
        SceneManager.LoadScene(lvl);
        data.up += data.record;
        data.lvl = lvl;
    }
}
