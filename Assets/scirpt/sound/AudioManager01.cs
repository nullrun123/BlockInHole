
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSourse;
    [SerializeField] AudioSource SFXSourse;

    [Header("----Audio clip---")]
    public AudioClip background;
    public AudioClip wallTouch;
    public AudioClip enemyattack;
    public AudioClip death;
    public AudioClip carattack;
    public AudioClip walk;
    public AudioClip buttonclick;
    public AudioClip mons;
    public AudioClip bulletgun;
    public AudioClip winner;
    public AudioClip fallwater;
    public AudioClip ballActive;
    private void Start()
    {
        musicSourse.clip = background;
        musicSourse.Play();

    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSourse.PlayOneShot(clip);
    }
}
