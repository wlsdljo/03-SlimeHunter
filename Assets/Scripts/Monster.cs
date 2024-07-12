using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private HPbar hpBar;
    [SerializeField] private float maxHP;
    [SerializeField] private Text nameText;
    [SerializeField] private string monsterName;
    private Animator animator;
    private float curHP;

    private bool isDead = false;

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
            Destroy(gameObject, 1.5f);
        }
    }
}
