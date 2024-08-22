using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] private int score;

    public float GetHalfSizeX => col.size.x * 0.5f;

    public int Score => score;
    
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
        ScoreManager.instance.AddScore(score, transform.position);
    }
}
