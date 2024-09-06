using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPower;
    private Platform landedPlatform;

    private Rigidbody2D rigd;
    private Animator anim;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("StateID", 1);
        }
        else if (Input.GetKey(KeyCode.Space)) 
        {
            JumpPower += DataBaseManager.Instance.JumpPowerIncrease;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rigd.AddForce(Vector2.one * JumpPower);
            JumpPower = 0;

            anim.SetInteger("StateID", 2);

            Define.SfxType sfxType = Random.value < 0.5f ? Define.SfxType.Jump1 : Define.SfxType.Jump2;
            SoundManager.Instance.PlaySfx(sfxType);

            Effect effect = Instantiate(DataBaseManager.Instance.effect);
            effect.Active(transform.position);
        }

        if (transform.position.y < DataBaseManager.Instance.GameOverY)
        {
            GameManager.Instance.OnGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigd.velocity = Vector2.zero;
        anim.SetInteger("StateID", 0);

        CameraManager.Instance.OnFollow(transform.position);

        if (collision.transform.TryGetComponent(out Platform platrform))
        {
            PlatformManager.Instance.LandingPlatformNum = platrform.number;
            platrform.OnLandingAnimation();

            if(landedPlatform == null)
            {
                landedPlatform = platrform;
                return;
            }

            if (landedPlatform != platrform) ScoreManager.Instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
            else ScoreManager.Instance.ResetBonus(transform.position);

            ScoreManager.Instance.AddScore(platrform.Score, platrform.transform.position);

            landedPlatform = platrform;
        }
    }
}
