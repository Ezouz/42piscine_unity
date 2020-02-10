using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    #region Singleton
    public static StatsUI instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public string hero = "GG";
    // stats panel
    public bool HudIsOpen = false;
    public bool hudClosed = false;
    public bool StatIsOpen = false;
    public bool statClosed = false;
    public Text HPUI;
    public Text minDamageUI;
    public Text maxDamageUI;
    public Text strenghUI;
    public Text agilityUI;
    public Text constitutionUI;
    public Text levelUI;
    public Text XPUI;
    public Text nlXPUI;
    // public Text armorUI;
    // public Text moneyUI;

    // mini Huds
    // enemy
    public Interactable focus;
    public CharacterStats enemy;
    public Text enemyName;
    public Text enemyLvl;
    public Text enemyHP;
    public Slider enemySlider;
    // player
    public Text playerName;
    public Text playerLvl;
    public Text playerHP;
    public Slider playerHPslider;
    public Text playerXP;
    public Slider playerXPslider;
    // public Button FOR;
    // public Button AGI;
    // public Button CON;
    public Text points;

    void Start()
    {
        playerName.text = hero;
        // CON.onClick.AddListener(AddCON);
        // AGI.onClick.AddListener(AddAgi);
        // FOR.onClick.AddListener(AddStr);
    }
    void StatsPanel () {
        if (StatIsOpen) {
            points.text = PlayerManager.instance.stats.points.ToString();
            HPUI.text = PlayerManager.instance.stats.HP.ToString() + " / " + PlayerManager.instance.stats.maxHP.ToString();
            minDamageUI.text = PlayerManager.instance.stats.minDamage.GetValue().ToString();
            maxDamageUI.text = PlayerManager.instance.stats.maxDamage.GetValue().ToString();
            strenghUI.text = PlayerManager.instance.stats.strengh.GetValue().ToString();
            agilityUI.text = PlayerManager.instance.stats.agility.GetValue().ToString();
            constitutionUI.text = PlayerManager.instance.stats.constitution.GetValue().ToString();
            levelUI.text = PlayerManager.instance.stats.level.ToString();
            XPUI.text = PlayerManager.instance.stats.XP.ToString();
            nlXPUI.text = PlayerManager.instance.stats.nlXP.ToString();
            if (statClosed) {
                // !! a voir apres le merge
                transform.GetChild(2).gameObject.SetActive(true);
                statClosed = false;
            }
        } else {
            if (!statClosed) {
                // !! a voir apres le merge
                transform.GetChild(2).gameObject.SetActive(false);
                statClosed = true;
            }
        }
    }
    public void EnemyHud()
    {
        if (focus != null) {
            if (!hudClosed)
            {
                // !! a voir apres le merge
                transform.GetChild(1).gameObject.SetActive(true);
                hudClosed = true;
                if (focus != null) {
                    if (focus.gameObject.tag == "enemy") {
                        enemy = focus.gameObject.transform.GetComponent<Enemy>().myStats;
                    }
                }
            }
			if (enemy != null)
            {
				enemyName.text = "enemy";
	            enemyLvl.text = enemy.level.ToString();
	            enemySlider.value = (float)((float)enemy.HP / (float)enemy.maxHP);
	            enemyHP.text = enemy.HP.ToString() + " / " + enemy.maxHP.ToString();
	            transform.GetChild(1).transform.position = Camera.main.WorldToScreenPoint(enemy.transform.position + (Vector3.up * 2));
			}
        } else {
            if (hudClosed)
            {
                // !! a voir apres le merge
                transform.GetChild(1).gameObject.SetActive(false);
                hudClosed = false;
            }
        }
    }
    public void HeroHud()
    {
        playerLvl.text = PlayerManager.instance.stats.level.ToString();
        playerHP.text = PlayerManager.instance.stats.HP.ToString() + " / " + PlayerManager.instance.stats.maxHP.ToString();
        playerHPslider.value = (float)((float)PlayerManager.instance.stats.HP / (float)PlayerManager.instance.stats.maxHP);
        playerXP.text = PlayerManager.instance.stats.XP.ToString();
        playerXPslider.value = (float)((float)PlayerManager.instance.stats.XP / (float)PlayerManager.instance.stats.nlXP);
        transform.GetChild(0).transform.position = Camera.main.WorldToScreenPoint(PlayerManager.instance.player.transform.position + (Vector3.up * 2));
    }

    public void AddStr()
    {
        if (PlayerManager.instance.stats.points > 0)
        {
            PlayerManager.instance.stats.points--;
            PlayerManager.instance.stats.strengh.AddModifier(1);
        }
    }

    public void AddAgi()
    {
        if (PlayerManager.instance.stats.points > 0)
        {
            PlayerManager.instance.stats.points--;
            PlayerManager.instance.stats.agility.AddModifier(1);
        }
    }
    public void AddCON()
    {
        if (PlayerManager.instance.stats.points > 0)
        {
            PlayerManager.instance.stats.points--;
            PlayerManager.instance.stats.constitution.AddModifier(1);
            PlayerManager.instance.stats.maxHP = PlayerManager.instance.stats.constitution.GetValue() * 5;
            PlayerManager.instance.stats.GainHealth(PlayerManager.instance.stats.maxHP);
        }
    }

    void Update()
    {
        StatsPanel();
        EnemyHud();
        HeroHud();
    }
}
