using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower = 0;
    private Platform landedPlatform;

    private Rigidbody2D rigd;
    private Animator anim;
    private bool isJumpReady;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    internal void Init()
    {
        
    }

    private void Update()
    {
        if (isJumpReady == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumpReady = true;
                anim.SetInteger("StateID", 1);
            }
        }
        else
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrease * Time.deltaTime;
            if (JumpPower < DataBaseManager.Instance.maxJumpPower)
            {
                SetIdleState();
                return;
            }
                
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumpReady = false;
                if (JumpPower < DataBaseManager.Instance.minJumpPower)
                {
                    SetIdleState();
                    
                }
                else
                {
                    rigd.AddForce(Vector2.one * JumpPower);
                    JumpPower = 0;

                    anim.SetInteger("StateID", 2);

                    Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
                    SoundManager.Instance.PlaySfx(sfxType);

                    Effect effect = Instantiate(DataBaseManager.Instance.effect);
                    effect.Active(transform.position);
                }
            }
        }
        
        if (transform.position.y < DataBaseManager.Instance.GameOverY)
        {
            GameManager.Instance.OnGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetIdleState();

        CameraManager.Instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platrform))
        {
            PlatformManager.Instance.LandingPlatformNum = platrform.number;
            platrform.OnLandingAnimation();

            if (landedPlatform == null)
            {
                landedPlatform = platrform;
                return;
            }

            if (landedPlatform != platrform) 
                ScoreManager.Instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            else 
                ScoreManager.Instance.ResetBonus(transform.position);

            ScoreManager.Instance.AddScore(platrform.Score, platrform.transform.position);

            landedPlatform = platrform;
        }
    }

    private void SetIdleState()
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);
        JumpPower = 0;
        isJumpReady = false;
    }
}
