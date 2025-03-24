using UnityEngine;

public class Fight : MonoBehaviour
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private float timeBetweenAttacks = 1f; // 1 second between each attack
    private float attackTimer = 0f;
    private bool isFighting = false;

    public Fight(Inhabitant attacker, Inhabitant defender)
    {
        this.attacker = attacker;
        this.defender = defender;
    }

    public void StartFight()
    {
        isFighting = true;
        attackTimer = timeBetweenAttacks; // Reset timer
    }

    void Update()
    {
        if (isFighting)
        {
            attackTimer -= Time.deltaTime; // Decrease the timer based on elapsed time

            if (attackTimer <= 0)
            {
                ExecuteAttack();
                attackTimer = timeBetweenAttacks; // Reset the timer after each attack
            }
        }
    }

    private void ExecuteAttack()
    {
        Inhabitant currentAttacker = attacker;
        Inhabitant currentDefender = defender;

        Debug.Log(currentAttacker.GetName() + " attacks " + currentDefender.GetName());

        int attackRoll = Random.Range(1, 21);
        if (attackRoll >= currentDefender.GetAC())
        {
            int damage = Random.Range(1, 5);
            currentDefender.TakeDamage(damage);
            Debug.Log(currentAttacker.GetName() + " hits for " + damage + " damage!");
            if (currentDefender.IsDead())
            {
                Debug.Log(currentDefender.GetName() + " has been defeated!");
                isFighting = false; // End the fight
            }
        }
        else
        {
            Debug.Log(currentAttacker.GetName() + " misses the attack.");
            if (attackRoll == 1)
            {
                Debug.Log("**** Critical Miss! **** " + currentAttacker.GetName() + " stumbles!");
            }
        }

        // Swap attacker and defender for the next round
        Inhabitant temp = currentAttacker;
        currentAttacker = currentDefender;
        currentDefender = temp;
    }
}
