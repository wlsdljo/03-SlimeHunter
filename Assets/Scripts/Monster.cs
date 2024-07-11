using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float curHP;

    private bool isDead = false;

    private void Awake()
    {
        curHP = maxHP;
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

        if (isDead)
        {
            Debug.Log("Slime is Dead");
            Destroy(gameObject, 1.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
