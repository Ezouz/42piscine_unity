using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHP = 3; // 5 * CON
    public int HP { get; private set; }
    public Stat minDamage; // STR / 2
    public Stat maxDamage; // minDamage + 4
    public Stat armor; // equip
    public Stat strengh; // STR
    public float attackSpeed;
    public Stat agility; // AGI
    public Stat constitution; // CON
    public int level;
    public int XP;
    public int nlXP; // next level XP
    public int points;
    public int XPvalue; // ce que rapporte l'enemi

    private void Awake()
    {
        maxHP = 5 * constitution.GetValue();
        HP = maxHP;
    }
    private void Update()
    {
    }

    public void LevelUp(int addXP) {
        Debug.Log("addXP " + addXP);
        XP += addXP;
        if (XP >= nlXP) {
            level += 1;
            XP = XP - nlXP;
            nlXP = nlXP + 1;
            points += 5;
            PlayerManager.instance.player.gameObject.GetComponentInParent<PlayerSkills>().skillPoints += 1;
            maxHP = constitution.GetValue() * 5;
            HP = maxHP;
        }
        Debug.Log("XP " + XP);
    }
    public void SetLife(int hp)
    {
        maxHP = hp;
        HP = maxHP;
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

	public void GainHealth(int i)
    {
        //damage -= armor.GetValue();
        // damage = Mathf.Clamp(damage, 0, int.MaxValue);
        HP += i;
        if (HP > maxHP)
        {
            HP = maxHP;
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
