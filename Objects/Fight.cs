using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    public Fight()
    {
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
        }
        else
        {
            Debug.Log("Player goes first");
        }

    }

    public void startFight()
    {
        Inhabitant currentAttacker = this.attacker;
        Inhabitant currentDefender = this.defender;
    
        while (true)
        {
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
                break;
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

        Inhabitant temp = currentAttacker;
        currentAttacker = currentDefender;
        currentDefender = temp;
    }
}
