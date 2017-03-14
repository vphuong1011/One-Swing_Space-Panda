using UnityEngine;
using System.Collections;

public enum PlayerState
{
    PLAYER_SPAWNING,
    PLAYER_IDLE,
    PLAYER_MOVING,
    PLAYER_ATTACKING,
    PLAYER_HIT,
    PLAYER_DYING,
    PLAYER_DEAD
}

public class Player : MonoBehaviour {
     Animator anim;
    int withdrawHash = Animator.StringToHash("Withdraw");


    // The player's current state
    PlayerState CurrentState = PlayerState.PLAYER_IDLE;

    private void Start()
    {
        anim = GetComponent<Animator>();
    } 
    // Update is called once per frame
    void Update() {
        // Player STATE MACHINE
        switch (CurrentState)
        {
            case PlayerState.PLAYER_IDLE:
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger(withdrawHash);
                }
                break;

        }
    }
}
