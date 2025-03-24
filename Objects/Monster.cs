using UnityEngine;
using UnityEngine.UI;

public class Monster : Inhabitant
{
    public Slider healthBar;

    public Monster(string name) : base(name)
    {
        this.healthBar = GameObject.Find("MonsterHealthBar").GetComponent<Slider>();
    }

    public void UpdateHealthBar()
    {
        healthBar.value = (float)currHp / maxHp;
    }
}
