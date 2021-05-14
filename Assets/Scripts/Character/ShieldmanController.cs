using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldmanController : MonoBehaviour
{
    // singleton? or ? 
    GameObject myButton;
    public int maxHealth = 6;
    int attackAbility = 1;
    [SerializeField] private int currentHealth = 3;

    public int health
    {
        get{return currentHealth;}
    }
    public int attack
    {
        get{return attackAbility;}
    }
    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            // 피격 효과 애니메이션 처리
        }
        else
        {
            // 회복 효과 애니메이션 처리
        }
        // Clamp 메소드 -> 최소 0, 최대 maxHealth로 구현
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + " / " + maxHealth);
        if(currentHealth <= 0) 
        {
            Destroy(gameObject);
            // 이벤트함수 호출 
        }
    }
    public void ChangeAttackAbility(int amount)
    {
        // Attack능력 최대값 2
        attackAbility = Mathf.Clamp(attackAbility + amount, 0, 2);
        Debug.Log("Attack Stat : " + attackAbility);        
    }
    public void GenerateButton(GameObject button)
    {
        Vector2 position = GetComponent<Rigidbody2D>().position;
        GameObject newButton = Instantiate(button, position + Vector2.up * 1.5f, Quaternion.identity);
        myButton = newButton; 
        myButton.transform.parent = gameObject.transform;
    }
    public void DeleteButton()
    {
        Destroy(myButton);
        Debug.Log("Delete");
    }
}