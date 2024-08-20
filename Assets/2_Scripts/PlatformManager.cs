
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
        Vector3 pos = transform.position;
        Debug.Log("DataArr.length : " + DataBaseManager.Instance.DataArr.Length);
        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
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

        float gap = Random.Range(DataBaseManager.Instance.GapIntervalMin, DataBaseManager.Instance.GapIntervalMax);
        pos = pos + Vector3.right * (platform.HalfSizeX + gap);
        return pos;
    }

}
