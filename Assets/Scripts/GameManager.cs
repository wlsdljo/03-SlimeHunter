using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slime;
    [SerializeField] private float damage;
    [SerializeField] private float criticalDamage;
    [SerializeField] private float probability;

    [SerializeField] private Text nameText;
    [SerializeField] private string userName;

    [SerializeField] private Text gold;
    private Monster curSlime;
    public float myGold;

    [SerializeField] private int LevelUp;
    [SerializeField] private Text curLevel;
    private float userLevel;
    public int times;

    public void SpawnSlime()
    {
        int spawnIndex = UnityEngine.Random.Range(0, slime.Length);
        GameObject newSlime = Instantiate(slime[spawnIndex].gameObject);
        curSlime = newSlime.GetComponent<Monster>();
    }

    private void Start()
    {
        nameText.text = userName;
    }

    void Awake()
    {
            SpawnSlime();
    }

    void Update()
    {
        if(curSlime == null)
        {
            SpawnSlime();
            times++;
        }

        if (times >= LevelUp)
        {
            userLevel++;
            LevelUp += 1;
            times = 0;
            curLevel.text = userLevel.ToString();
        }
    }

    public void HitSlime()
    {
        if(curSlime != null)
        {
            int curProbability = UnityEngine.Random.Range(0, 100);
            if (curProbability > probability)
                curSlime.OnHit(damage);
            else if (curProbability < probability)
            {
                curSlime.OnHit(criticalDamage);
                Debug.Log("Critical!");
            }
            myGold += curSlime.curGold;
            gold.text = myGold.ToString();
        }
    }
}