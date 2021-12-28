using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player), typeof(PlayerInput))]
public class PlayerInvincibility : MonoBehaviour
{
    [SerializeField] private GameObject invincibilityFireEffect;
    [SerializeField] private GameObject invincibilityBG;
    [SerializeField] private Image invincibilityFill;
    private bool isUIWasClicked;

    private Player player;
    private PlayerInput playerInput;
    private float pressingTime;
    public bool IsInvincible { get; set; }
    private void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void FixedUpdate()
    {
        if (!isUIWasClicked)
        {
            if (player.PlayerState == Player.playerState.Playing)
            {
                if (IsInvincible)
                {
                    pressingTime -= Time.fixedDeltaTime * .7f;
                    if (!invincibilityFireEffect.activeInHierarchy)
                    {
                        invincibilityFireEffect.SetActive(true);
                    }
                }
                else
                {
                    if (invincibilityFireEffect.activeInHierarchy)
                    {
                        invincibilityFireEffect.SetActive(false);
                    }
                    if (playerInput.IsHoldingTouch)
                    {
                        pressingTime += Time.fixedDeltaTime * .8f;
                    }
                    else
                    {
                        pressingTime -= Time.fixedDeltaTime * .5f;
                    }
                }

                if (pressingTime >= 0.15f || invincibilityFill.color == Color.red)
                    invincibilityBG.SetActive(true);
                else
                    invincibilityBG.SetActive(false);

                if (pressingTime >= 1)
                {
                    pressingTime = 1;
                    IsInvincible = true;
                    invincibilityFill.color = Color.red;
                }
                else if (pressingTime <= 0)
                {
                    pressingTime = 0;
                    IsInvincible = false;
                    invincibilityFill.color = Color.white;
                }

                if (invincibilityBG.activeInHierarchy)
                {
                    invincibilityFill.fillAmount = pressingTime / (float)1;
                }
            }
        }
    }
    public void OnUIWasClicked(bool IsUIWasClicked)
    {
        isUIWasClicked = IsUIWasClicked;
    }
}
