using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//캐릭터 피격시 이벤트
public class CharacterHPScript : MonoBehaviour
{
    public int m_MaxBeAttacked = 0;

    const string isDamage = "IsDamage";
    const string isRun = "IsRun";
    int HP = 0;

    Animator animator;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP -= 1;

            animator.SetBool(isRun, false);
            animator.SetBool(isDamage, true);


            //사망시 Vertigo씬으로 전환
            if (HP == 0)
            {
                SceneManager.LoadScene("Scenes/Vertigo");
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = m_MaxBeAttacked;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Damage"))
        {
            Debug.Log("damage 종료");
            this.animator.SetBool(isDamage, false);
        }
    }
}
