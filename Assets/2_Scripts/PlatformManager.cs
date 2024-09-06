
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        [Tooltip("�÷��� �׷� ����")] public int GroupCount;
        [Tooltip("ū �÷��� ����(0~1.0"), Range(0, 1f)][SerializeField] public float largePercent;
        [Tooltip("�߰� �÷��� ����(0~1.0"), Range(0, 1f)][SerializeField] public float middlePercent;
        [Tooltip("���� �÷��� ����(0~!.0"), Range(0, 5f)][SerializeField] public float smallPercent;

        public int GetplatformID()
        {
            float randval = Random.value;
            int platformID;
            if (randval <= largePercent)
            {
                platformID = 2;
            }
            else if (randval <= largePercent + middlePercent)
            {
                platformID = 1;
            }
            else
            {
                platformID = 0;
            }

            return platformID;
        }
    }

    private Vector3 spawnPos;
    [SerializeField] private Transform spawnPosTrf;

    private int platformNum = 0;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    internal void Init()
    {
        PlatformArrDic.Add(0, DataBaseManager.Instance.SmallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }

    internal void Active()
    {
        spawnPos = spawnPosTrf.position;

        
        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum: {platformGroupSum} =========");
            while(platformNum <  platformGroupSum)
            {
                int platformID = data.GetplatformID();
                ActiveOne(platformID);
                platformNum++;
            }
        }
        
    }

    private  void ActiveOne(int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];
        Debug.Log($"Platform [{platformID}, {randID}]");

        Platform platform = Instantiate(randomplatform);

        bool isFirstFrame = platformNum == 0;
        if (isFirstFrame == false)
            spawnPos = spawnPos + Vector3.right * platform.HalfSizeX;

      
        platform.Active(spawnPos, isFirstFrame);

        float gap = Random.Range(DataBaseManager.Instance.GapIntervalMin, DataBaseManager.Instance.GapIntervalMax);
        spawnPos = spawnPos + Vector3.right * (platform.HalfSizeX + gap);
        return;
    }

}
