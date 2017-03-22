using UnityEngine;

public enum EnemyState
{
    Bandit_SPAWNING,
    Bandit_IDLE,
    Bandit_MOVING,
    Bandit_ATTACKING,
    Bandit_HIT,
    Bandit_DYING,
    PLAYER_DEAD
}

public class Enemy : MonoBehaviour
{

    // The player's current state
    EnemyState CurrentState = EnemyState.Bandit_IDLE;

    // Update is called once per frame
    void Update()
    {
        // Player STATE MACHINE
        switch (CurrentState)
        {
            case EnemyState.Bandit_IDLE:
                break;

        }
        {
            switch(CurrentState)
            {
                case EnemyState.Bandit_ATTACKING:
                    break;
                    }
        }
    }
}
