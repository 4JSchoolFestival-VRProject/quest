using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpRequest : MonoBehaviour{

    private int maxHp;
    public bool flag;
    private int Hp;
    public Enemy enemy;
    private Slider hpslider;
    
    private void setMaxHp()
    {
        hpslider.value = maxHp;
    }
    
    public int Max
    {
        set { maxHp = value; }
    }

    public int CurrentHp
    {
        set { Hp = value; }
    }

    public void Request(int value)
    { 
        Hp = value;
        hpslider.value = value;
    }

    public void SetEnemy(Enemy e)
    {
        enemy = e;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void EnemyHpInitialized(int max, int now)
    {
        Max = max;
        CurrentHp = now;
        Debug.Log("aaaa");
        hpslider.maxValue = maxHp;
        hpslider.minValue = 0;
        setMaxHp();
     //   Debug.Log("aaaasssssss");

    }

    void Start()
    {
        hpslider = transform.Find("HpBar").GetComponent<Slider>();
        EnemyHpInitialized(enemy.Hp, enemy.Hp);
        enemy.HpBar(this);
        Debug.Log("aaaa");
        
    }

    // Update is called once per frame
    void Update () {
        if (flag) return;

        transform.rotation = Camera.main.transform.rotation;
    }
}
