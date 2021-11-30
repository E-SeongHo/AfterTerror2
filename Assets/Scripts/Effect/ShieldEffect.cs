using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EffectManage.cs -> SuccessShield()
/// 1. ����Ʈ�� �������� �� �� �ش� ��ġ�� �ű� �� SetActive(true) ��Ų��.
/// 2. OnEnable()�� ���� �ִϸ��̼� ���
/// 3. ���� caller�� ActiveOff() ȣ���Ͽ� �ٽ� SetActive(false) 
///  3 -> Animation event�� ���� ó���ϵ��� �����Ͽ���.
/// </summary>
public class ShieldEffect : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if(animator != null)
            animator.SetTrigger("generate");
    }
    private void ActiveOff()
    {
        gameObject.SetActive(false);
    }
}