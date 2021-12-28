using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    private Player player;
    public UnityEvent RestartThisLevel;
    [SerializeField] GameObject PlayerDeathParticles;
    [SerializeField] GameObject PlayerVisuals;
    private PlayerInput playerInput;
    private bool checkForPlayerDeath;

    MeshRenderer playerMeshRenderer;
    private void Start()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
        playerMeshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
    }
    public void OnPlayerDead()
    {

        playerMeshRenderer.enabled = false;
        PlayerVisuals.SetActive(false);
        PlayerDeathParticles.SetActive(true);
        //turnOffComponents
        GetComponent<SphereCollider>().enabled = false;
        //GetComponent<Player>().enabled = true;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        GetComponent<PlayerSounds>().enabled = false;
        GetComponent<PlayerInvincibility>().enabled = false;
        GetComponent<PlayerSplashFX>().enabled = false;
        Invoke("ChangeCheckForPlayerDeath",1);
    }
    private void Update()
    {
        if (checkForPlayerDeath)
        {
            if (player.PlayerState == Player.playerState.Died)
            {
                if (playerInput.IsHoldingTouch)
                {
                    RestartThisLevel?.Invoke();
                    GetComponent<PlayerInput>().enabled = false;
                }
            }
        }
    }
    private void ChangeCheckForPlayerDeath()
    {
        checkForPlayerDeath=true;
    }

}
