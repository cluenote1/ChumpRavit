using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("¿¬Ãâ")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;
    public Effect effect;

    [Header("¾ÆÀÌÅÛ")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;

    [Header("ÇÃ·¹ÀÌ¾î")]
    public float JumpPowerIncrease = 1;
    public float GameOverY = -6.5f;

    [Header("ÇÃ·¿Æû")]
    [Tooltip("Å« ÇÃ·¿Æû Preb")] public Platform[] LargePlatformArr;
    [Tooltip("Áß°£ ÇÃ·¿Æû Preb")] public Platform[] MiddlePlatformArr;
    [Tooltip("ÀÛÀº ÇÃ·¿Æû Preb")] public Platform[] SmallPlatformArr;
    [Tooltip("ÇÃ·¿Æû ¹èÄ¡")] public PlatformManager.Data[] DataArr;

    [Tooltip("ÇÃ·¿Æû ÃÖ¼Ò°£°Ý")] public float GapIntervalMin = 1.0f;
    [Tooltip("ÇÃ·¿Æû ÃÖ´ë °£°Ý")] public float GapIntervalMax = 2.0f;
    [Tooltip("º¸³Ê½º Ãß°¡ ")] public float BonusValue = 0.05f;

    [Header("Ä«¸Þ¶ó")]
    public float followSpeed = 5;

    [Header("»ç¿îµå")]
    public SfxData[] sfxDataArr;
    public BgmData[] bgmDataArr;
    private Dictionary<Define.SfxType, SfxData> sfxDataDic;
    private Dictionary<Define.BgmType, BgmData> bgmDataDic;

    public void Init()
    {
        Instance = this;
        sfxDataDic = new Dictionary<Define.SfxType, SfxData>();
       

        foreach (SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }

        bgmDataDic = new Dictionary<Define.BgmType, BgmData>();
        foreach (BgmData data in bgmDataArr)
        {
            bgmDataDic.Add(data.bgmType, data);
        }
    }

    public SfxData GetSfxData(Define.SfxType type)
    {
        return sfxDataDic[type];
    }
    public BgmData GetBgmData(Define.BgmType type)
    {
        return bgmDataDic[type];
    }

    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1;
    }

    [System.Serializable]
    public class SfxData : SoundData
    {
        public Define.SfxType sfxType;
    }

    [System.Serializable]
    public class BgmData : SoundData
    {
        public Define.BgmType bgmType;
    }
}
