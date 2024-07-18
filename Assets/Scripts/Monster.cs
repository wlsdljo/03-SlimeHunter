using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private HPbar hpBar;
    [SerializeField] private float maxHP;
    private bool isDead = false;

    [SerializeField] private Text nameText;
    [SerializeField] private string monsterName;
    private Animator animator;
    public float curHP;

    [SerializeField] public float getGold;
    public float curGold;

    private void Awake()
    {
        curHP = maxHP;
        animator = GetComponent<Animator>();
        nameText.text = monsterName;
    }

    public void OnHit(float damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            curHP = 0;
            isDead = true;
        }
        Debug.Log("Slime Hit!, Current HP : " + curHP);
        hpBar.ChangeHpBarAmount(curHP / maxHP);
        animator.SetTrigger("Hit");

        if (isDead)
        {
            Debug.Log("Slime is Dead");
            animator.SetTrigger("Death");
            curGold += getGold;
            Destroy(gameObject, 1.5f);
        }
    }
}
