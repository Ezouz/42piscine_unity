using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHP = 3; // 5 * CON
    public int HP { get; private set; }
    public Stat damage;
    public Stat minDamage; // STR / 2
    public Stat maxDamage; // minDamage + 4
    public Stat armor; // equip
    public Stat strengh; // STR
    public Stat agility; // AGI
    public Stat constitution; // CON
    public Stat level;
    public Stat XP;
    public Stat nlXP; // next level XP
    public Stat money;


    private void Awake()
    {
        maxHP = 5 * constitution.GetValue();
        HP = maxHP;
    }
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //   TakeDamage(10);
        // }
    }

    public void TakeDamage(int damage)
    {
        //damage -= armor.GetValue();
        // damage = Mathf.Clamp(damage, 0, int.MaxValue);

        HP -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        if (HP <= 0)
        {
            Die();
        }
    }

    public void ResetHealth() {
        HP = maxHP;
    }

    public virtual void Die()
    {
        // Die
        Debug.Log(transform.name + " dies.");
    }
}