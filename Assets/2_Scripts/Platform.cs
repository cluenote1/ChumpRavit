using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] private int Score;

    public float HalfSizeX => col.size.x * 0.5f;
    public float GetHalfSizeX()
    {
        return col.size.x * col.size.x;
    }
    private void Awake()
    {
        col = GetComponentInChildren<BoxCollider2D>();
    }
    public void Active(Vector2 pos)
    {
        transform.position = pos;
    }
    internal void OnLanding()
    {
        ScoreManager.instance.AddScore(Score);
    }
}
