using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("ÇÃ·¹ÀÌ¾î")]
    public float JumpPowerIncrease = 1;

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

    public void Init()
    {
        Instance = this;
    }
}
