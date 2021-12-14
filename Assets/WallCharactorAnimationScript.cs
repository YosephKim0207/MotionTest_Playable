using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCharactorAnimationScript : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;

    // 設定したフラグの名前
    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";
    // 初期化メソッド
    void Start()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
    }

    // 1フレームに1回コールされる
    void Update()
    {
        // 矢印上ボタンを押下している
        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            // IdleからRunに遷移する
            this.animator.SetBool(key_isRun, true);
        }
        else
        {
            // RunからIdleに遷移する
            this.animator.SetBool(key_isRun, false);
        }

        // ジャンプ spaceを押す
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Jumpに遷移する
            this.animator.SetBool(key_isJump, true);
        }
        else
        {
            // JumpからIdleに遷移する
            this.animator.SetBool(key_isJump, false);
        }
    }
}
