using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//音量管理脚本，PersistentSingleton为持续泛型单例父类
//派生此单例父类可以使脚本挂载的物体不随场景改变而销毁
//并且使其他脚本更容易调用本脚本内容
public class AudioManager : PersistentSingleton<AudioManager>
{
    //AudioMixer组件的引用
    [SerializeField] AudioMixer audioMixer;

    //音量设置
    //Slider on click:点击滑动条图片时，改变对应AudioMixer属性的值

    public void MasterSldOnClick(GameObject image, Slider slider)
    {
        audioMixer.SetFloat("Master", slider.value);
    }
    public void BgmSldOnClick(GameObject image, Slider slider)
    {
        audioMixer.SetFloat("Bgm", slider.value);
    }
    public void SeSldOnClick(GameObject image, Slider slider)
    {
        audioMixer.SetFloat("Se", slider.value);
    }

}
