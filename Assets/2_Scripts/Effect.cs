using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void Active(Vector3 pos)
    {
        transform.position = pos + new Vector3(-0.2f, 0.1f, 0);
    }

    public void CallAni()
    {
        Destroy(gameObject);
    }
}
