using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {
	public AudioClip[] clip;
    public void Step()
    {
        int num = Random.Range(0, clip.Length-1);
        SoundPlayer.regit.sorse.PlayOneShot(clip[num]);
    }
}
