using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpRequest : MonoBehaviour{

    private int maxHp;
    private int Hp;
    private Enemy enemy;
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

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void EnemyHpInitialized(int max, int now)
    {
        Max = max;
        CurrentHp = now;
     //   Debug.Log("aaaa");
        hpslider.maxValue = maxHp;
        hpslider.minValue = 0;
        setMaxHp();
     //   Debug.Log("aaaasssssss");

    }

    void Start()
    {
        enemy = transform.root.GetComponent<Enemy>();
       // Debug.Log("enemy:" + enemy.Hp);
        hpslider = transform.Find("HpBar").GetComponent<Slider>();
        EnemyHpInitialized(enemy.Hp, enemy.Hp);
        enemy.HpBar(this);
    }

    // Update is called once per frame
    void Update () {
        transform.rotation = Camera.main.transform.rotation;
    }
}
