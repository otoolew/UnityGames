using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int curHP;
    public int maxHP;
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int amount)
    {
        curHP -= amount;
    }
    public IEnumerator Death()
    {
        anim.SetTrigger("Die");     
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }
}
