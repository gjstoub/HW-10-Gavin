using UnityEngine;
using UnityEngine.UI;

public class Player : Inhabitant
{
    public Slider healthBar;

    public Player(string name) : base(name)
    {
        this.healthBar = GameObject.Find("PlayerHealthBar").GetComponent<Slider>();
    }

    public void UpdateHealthBar()
    {
        healthBar.value = (float)currHp / maxHp;
    }
}
