using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int LifeMax = 100;
    public Sprite SpritePortrait;

    public SpriteRenderer Visual;

    public Animator Animator;

    public AudioClip Clip;

    public int Life = 100;

    internal void Attack(Character defender)
    {
        Animator.SetTrigger("Attack");
        defender.Hit();
        AudioManager.Instance.PlaySound(Clip);
    }

    internal void Hit()
    {
        Animator.SetTrigger("Hit");
    }
}
