using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Score : MonoBehaviour
{
    private TextMeshPro Tmp;

    private void Awake()
    {
        Tmp = GetComponentInChildren<TextMeshPro>();
    }

    public void Active(int score)
    {
        Tmp.text = score.ToString();
    }
    
    public void Deactive()
    {
        Destroy(gameObject);
    }
}
