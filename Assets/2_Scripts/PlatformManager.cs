
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [SerializeField] public float largePercent;
        [SerializeField] public float middlePercent;
        [SerializeField] public float smallPercent;

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

    [SerializeField] private Transform spawnPosTrf;
    [SerializeField] private Platform[] LargePlatformArr;
    [SerializeField] private Platform[] MiddlePlatformArr;
    [SerializeField] private Platform[] SmallPlatformArr;
    [SerializeField] private Data[] DataArr;
    private int platformNum = 0;

    [SerializeField] private float GapIntervalMin = 1.0f;
    [SerializeField] private float GapIntervalMax = 2.0f;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();
    internal void Init()
    {
        PlatformArrDic.Add(0, SmallPlatformArr);
        PlatformArrDic.Add(1, MiddlePlatformArr);
        PlatformArrDic.Add(2, LargePlatformArr);
    }

    internal void Active()
    {
        Vector3 pos = transform.position;
        Debug.Log("DataArr.length : " + DataArr.Length);
        int platformGroupSum = 0;
        foreach (Data data in DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum: {platformGroupSum} =========");
            while(platformNum <  platformGroupSum)
            {
                int platformID = data.GetplatformID();
                pos = ActiveOne(pos, platformID);
                platformNum++;
            }
        }
        
    }

    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];
        Debug.Log($"Platform [{platformID}, {randID}]");

        Platform platform = Instantiate(randomplatform);

        if (platformNum != 0)
            pos = pos + Vector3.right * platform.HalfSizeX;

      
        platform.Active(pos);

        float gap = Random.Range(GapIntervalMin, GapIntervalMax);
        pos = pos + Vector3.right * (platform.HalfSizeX + gap);
        return pos;
    }

}
