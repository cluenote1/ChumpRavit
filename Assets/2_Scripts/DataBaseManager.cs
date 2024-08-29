using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("����")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;

    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;

    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;

    [Header("�÷���")]
    [Tooltip("ū �÷��� Preb")] public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷��� Preb")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷��� Preb")] public Platform[] SmallPlatformArr;
    [Tooltip("�÷��� ��ġ")] public PlatformManager.Data[] DataArr;

    [Tooltip("�÷��� �ּҰ���")] public float GapIntervalMin = 1.0f;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervalMax = 2.0f;
    [Tooltip("���ʽ� �߰� ")] public float BonusValue = 0.05f;

    [Header("ī�޶�")]
    public float followSpeed = 5;

    public void Init()
    {
        Instance = this;
    }
}
