using UnityEngine;

public abstract class Inhabitant
{
    protected int currHp;
    protected int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(10, 20);
    }
}
public void TakeDamage(int damage)
{
    this.currHp -= damage;
    if (this.currHp < 0)
    {
        this.currHp = 0;
    }
}

public bool IsDead()
{
    return this.currHp <= 0;
}

public int GetAC()
{
    return this.ac;
}

public string GetName()
{
    return this.name;
}

