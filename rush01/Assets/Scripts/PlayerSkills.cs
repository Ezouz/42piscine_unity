using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public enum SkillType{None, AoeHero, AoeThrow, HealPower, MegaSpeed, FireBall, StatsIncrease};

public class PlayerSkills : MonoBehaviour
{
	public GameObject aoeHeroObject;
	public GameObject aoeThrowObject;
	public GameObject fireBallObject;
	public GameObject aoeThrowVisual;
	public GameObject fireBallVisual;
	public bool isCastingFireBall;
	public bool isCastingAoeThrow;
	public bool isCastingAoeHero;
	public bool isClickingOnButton;

	[SerializeField]private SkillType[] quickSkills = {SkillType.None, SkillType.None, SkillType.None, SkillType.None};
	public int skillPoints;
	[SerializeField]public int skillAoeHero;
	[SerializeField]public int skillAoeThrow;
	[SerializeField]public int skillHealPower;
	[SerializeField]public int skillMegaSpeed;
	[SerializeField]public int skillFireBall;
	[SerializeField]public int skillStatsIncrease;
	[SerializeField]private float mana;

	private GameObject skillsUI;
	private GameObject mayaObject;
	private PlayerController playerController;
	private PlayerStats playerStats;
	private NavMeshAgent playerAgent;
	private int skillSlotToUse = 0;
	private float manaRefill = 5f;
	private float manaAoeHeroCost = 80f;
	private float manaAoeThrowCost = 80f;
	private float manaHealCost = 20f;
	private float manaSpeedCost = 20f;
	private float manaFireCost = 50f;
	private float manaStatsCost = 20f;
	private bool showSkillsUI = true;

	void Start()
	{
		skillPoints = 0;
		skillAoeHero = 0;
		skillAoeThrow = 0;
		skillHealPower = 0;
		skillMegaSpeed = 0;
		skillFireBall = 0;
		skillStatsIncrease = 0;
		mana = 100f;
		isCastingFireBall = false;
		isCastingAoeThrow = false;
		isCastingAoeHero = false;
		isClickingOnButton = false;
		skillsUI = GameObject.Find("SkillsUI");
		mayaObject = GameObject.Find("Maya");
		playerController = mayaObject.GetComponent<PlayerController>();
		playerStats = mayaObject.GetComponent<PlayerStats>();
		playerAgent = mayaObject.GetComponent<NavMeshAgent>();
		toggleSkillsUI();
		refreshQuickSkillsUI();
	}

	void LateUpdate()
	{
		if (mana < 100f)
			mana = Mathf.Clamp(mana + (manaRefill * Time.deltaTime), 0f, 100f);

		if (Input.GetKeyDown(KeyCode.N))
		{
			toggleSkillsUI();
		}

		if (isCastingAoeThrow && Input.GetMouseButtonDown(0))
		{
			isCastingAoeThrow = false;
			playerController.itsASpell = true;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				EnemyHurtZone zone = Instantiate(aoeThrowObject, hit.point, Quaternion.identity).GetComponent<EnemyHurtZone>();
				zone.damage = skillAoeThrow;
			}
		}
		else if (isCastingFireBall && Input.GetMouseButtonDown(0))
		{
			playerController.itsASpell = true;
			isCastingFireBall = false;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				GameObject fireball = Instantiate(fireBallObject, mayaObject.transform.position + (mayaObject.transform.up * 2f), Quaternion.identity);
				fireball.GetComponent<FireballScript>().setDestination(hit.point);
				fireball.GetComponent<EnemyHurtZone>().damage = skillFireBall;
			}
		}
		else if (Input.GetMouseButtonDown(0))
		{
			isClickingOnButton = false;
			playerController.itsASpell = false;
		}
	}

	public void useSkillPoint(int i)
	{
		isClickingOnButton = true;
		if (skillPoints > 0)
		{
			switch (i)
			{
				case 0:
					skillAoeHero = upgradeSkill(skillAoeHero);
					break;
				case 1:
					if (playerStats.level >= 6)
						skillAoeThrow = upgradeSkill(skillAoeThrow);
					break;
				case 2:
					skillFireBall = upgradeSkill(skillFireBall);
					break;
				case 3:
					if (playerStats.level >= 6)
						skillStatsIncrease = upgradeSkill(skillStatsIncrease);
					break;
				case 4:
					skillHealPower = upgradeSkill(skillHealPower);
					break;
				case 5:
					if (playerStats.level >= 6)
						skillMegaSpeed = upgradeSkill(skillMegaSpeed);
					break;
			}
			refreshSkillsUI();
		}
	}

	public void equipSkill(int i)
	{
		isClickingOnButton = true;
		switch (i)
		{
			case 0:
				if (skillAoeHero > 0)
				{
					quickSkills[skillSlotToUse] = SkillType.AoeHero;
					skillSlotToUse = cycleSlotUse(skillSlotToUse + 1);
				}
				break;
			case 1:
				if (skillAoeThrow > 0)
				{
					quickSkills[skillSlotToUse] = SkillType.AoeThrow;
					skillSlotToUse = cycleSlotUse(skillSlotToUse + 1);
				}
				break;
			case 2:
				if (skillFireBall > 0)
				{
					quickSkills[skillSlotToUse] = SkillType.FireBall;
					skillSlotToUse = cycleSlotUse(skillSlotToUse + 1);
				}
				break;
			case 3:
				if (skillStatsIncrease > 0)
				{
					quickSkills[skillSlotToUse] = SkillType.StatsIncrease;
					skillSlotToUse = cycleSlotUse(skillSlotToUse + 1);
				}
				break;
			case 4:
				if (skillHealPower > 0)
				{
					quickSkills[skillSlotToUse] = SkillType.HealPower;
					skillSlotToUse = cycleSlotUse(skillSlotToUse + 1);
				}
				break;
			case 5:
				if (skillMegaSpeed > 0)
				{
					quickSkills[skillSlotToUse] = SkillType.MegaSpeed;
					skillSlotToUse = cycleSlotUse(skillSlotToUse + 1);
				}
				break;
		}
		refreshQuickSkillsUI();
	}

	public void useSkill(int i)
	{
		isClickingOnButton = true;
		switch (quickSkills[i])
		{
			case SkillType.AoeHero:
				if (mana >= manaAoeHeroCost)
					castAoeHero();
				break;
			case SkillType.AoeThrow:
				if (mana >= manaAoeThrowCost)
					castAoeThrow();
				break;
			case SkillType.HealPower:
				if (mana >= manaHealCost)
					castHeal();
				break;
			case SkillType.MegaSpeed:
				if (mana >= manaSpeedCost)
					castSpeed();
				break;
			case SkillType.FireBall:
				if (mana >= manaFireCost)
					castFireBall();
				break;
			case SkillType.StatsIncrease:
				if (mana >= manaStatsCost)
					castStats();
				break;
		}
	}

	private int upgradeSkill(int skill)
	{
		if (skill < 5)
		{
			skillPoints -= 1;
			return skill + 1;
		}
		return skill;
	}

	private void toggleSkillsUI()
	{
		showSkillsUI = !showSkillsUI;
		skillsUI.SetActive(showSkillsUI);

		if (showSkillsUI)
			refreshSkillsUI();
	}

	private void refreshSkillsUI()
	{
		GameObject.Find("skillPointsNumber").GetComponent<Text>().text = "Skill Points: " + skillPoints;
		GameObject.Find("skillPlayerLevelText").GetComponent<Text>().text = "Level: " + playerStats.level;
		GameObject.Find("textAoeHeroLevel").GetComponent<Text>().text = "Level: " + skillAoeHero + "/5";
		GameObject.Find("textAoeThrowLevel").GetComponent<Text>().text = "Level: " + skillAoeThrow + "/5";
		GameObject.Find("textHealLevel").GetComponent<Text>().text = "Level: " + skillHealPower + "/5";
		GameObject.Find("textSpeedLevel").GetComponent<Text>().text = "Level: " + skillMegaSpeed + "/5";
		GameObject.Find("textFireBallLevel").GetComponent<Text>().text = "Level: " + skillFireBall + "/5";
		GameObject.Find("textStatsIncreaseLevel").GetComponent<Text>().text = "Level: " + skillStatsIncrease + "/5";
	}

	private void refreshQuickSkillsUI()
	{
		GameObject.Find("buttonSkillOneText").GetComponent<Text>().text = getTypeName(quickSkills[0]);
		GameObject.Find("buttonSkillTwoText").GetComponent<Text>().text = getTypeName(quickSkills[1]);
		GameObject.Find("buttonSkillThreeText").GetComponent<Text>().text = getTypeName(quickSkills[2]);
		GameObject.Find("buttonSkillFourText").GetComponent<Text>().text = getTypeName(quickSkills[3]);
	}

	private string getTypeName(SkillType skill)
	{
		string sName = "No Skill";
		switch (skill)
		{
			case SkillType.AoeHero:
				sName = "Aoe Hero";
				break;
			case SkillType.AoeThrow:
				sName = "Aoe Throw";
				break;
			case SkillType.HealPower:
				sName = "Heal Power";
				break;
			case SkillType.MegaSpeed:
				sName = "Mega Speed";
				break;
			case SkillType.FireBall:
				sName = "Fire Ball";
				break;
			case SkillType.StatsIncrease:
				sName = "Stats Increase";
				break;
			}
		return sName;
	}

	private int cycleSlotUse(int slot)
	{
		if (slot > 3)
			return 0;
		return slot;
	}

	private void castHeal()
	{
		mana -= manaHealCost;
		playerStats.GainHealth(skillHealPower);
	}

	private void castSpeed()
	{
		mana -= manaSpeedCost;
		playerAgent.speed += skillMegaSpeed;
	}

	private void castStats()
	{
		mana -= manaStatsCost;
		playerStats.strengh.AddModifier(skillStatsIncrease);
		playerStats.agility.AddModifier(skillStatsIncrease);
		playerStats.constitution.AddModifier(skillStatsIncrease);
	}

	private void castFireBall()
	{
		if (!isCastingFireBall)
		{
			Instantiate(fireBallVisual, mayaObject.transform.position, Quaternion.identity);
			mana -= manaFireCost;
			isCastingFireBall = true;
		}
	}

	private void castAoeHero()
	{
		if (!isCastingAoeHero)
		{
			mana -= manaAoeHeroCost;
			EnemyHurtZone zone = Instantiate(aoeHeroObject, mayaObject.transform.position, Quaternion.identity).GetComponent<EnemyHurtZone>();
			zone.damage = skillAoeHero;
			isCastingAoeHero = true;
			Invoke("canCastAoeHeroAgain", 5f);
		}
	}

	private void canCastAoeHeroAgain()
	{
		isCastingAoeHero = false;
	}

	private void castAoeThrow()
	{
		if (!isCastingAoeThrow)
		{
			Instantiate(aoeThrowVisual, mayaObject.transform.position, Quaternion.identity);
			mana -= manaAoeThrowCost;
			isCastingAoeThrow = true;
		}
	}
}
