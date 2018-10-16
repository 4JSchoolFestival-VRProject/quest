using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour {

    private Animator ani;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();


	}
	
    public void AnimatorManager(string state)
    {
        ;
    }

    public void Walk(bool value)
    {
        ani.SetBool("Walk", value);
    }

    public void Attack(bool value)
    {
        ani.SetBool("Attack", value);
    }

    public void Idle(bool value)
    {
        ani.SetBool("Idle", value);
    }

    public void Stop(bool value)
    {

    }

	// Update is called once per frame
	void Update () {
		
	}
}
