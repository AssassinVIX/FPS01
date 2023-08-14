using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioResourceLogic : MonoBehaviour
{
    //改变音调
    const float pitchMin = 0.9f;
    const float pitchMax = 1.1f;

    //引用音频文件
    [SerializeField]AudioSource SePlayer;
    [SerializeField]AudioSource BgPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //播放音效
    public void PlaySound(AudioClip audioClip)
    {
        SePlayer.pitch = 1;
        SePlayer.PlayOneShot(audioClip);
    }

    // 改变音调，主要用于重复播放的音效
    public void PlayRandomSound(AudioClip audioClip)
    {
        SePlayer.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
        SePlayer.PlayOneShot(audioClip);
    }

    public void PlayBg(AudioClip audioClip)
    {
        BgPlayer.pitch = 1;
        BgPlayer.PlayOneShot(audioClip);
    }

    // 改变音调，主要用于重复播放的音效
    public void PlayRandomBg(AudioClip audioClip)
    {
        BgPlayer.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
        BgPlayer.PlayOneShot(audioClip);
    }

    public void PlayRandomSound(AudioClip[] audioClip)
    {
        PlayRandomSound(audioClip[UnityEngine.Random.Range(0, audioClip.Length)]);
    }
}
