using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
        dataBaseManager.Init();

        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.Init();
        soundManager.Init();
    }

    private void Start()
    {
        platformManager.Active();

        int a = 123456;
        Debug.Log("Extension Test int : " + a.ToString());

        float b = 123456.789f;
        

        MyExtension.ToFormatString(b, 0);
        b.ToFormatString();
    }
}
