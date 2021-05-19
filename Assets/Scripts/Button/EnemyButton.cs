using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyButtonManage Object�� �ʿ� Enemy�� ���� ����� ���� ã�� ��ư �ο�
// EnemyButton�� �� 9��
// EnemyButton�� ������ ������ EnemyButtonMange��ü�� ��� ���
// �ϳ����� ��ȣ�ۿ��ϴϱ� ����
public class EnemyButton : MonoBehaviour
{   
    // red ASD, green ASD, blue ASD
    // ���� GameObject�� ���ϰ� Sprite�迭�� �ص� �ɵ�
    // ���� ���ſ����� ����
    [SerializeField] private GameObject[] buttons = new GameObject[9];
    
    private GameObject[] enemies;
    private GameObject target = null;

    private GameObject nowButton;
    private bool buttonON = false;
    private int buttonidx; // A : 0, S : 1, D : 2
    
    private EnemyController enemyController;

    private void Update()
    {
        if(!buttonON)
        {
            // Find Nearest Enemy & Set varialbes with that Enemy
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            target = FindFunction.Instance.FindNearestObjectArr(enemies);
            if (target != null)
            {
                enemyController = target.GetComponent<EnemyController>();
                GiveButton(target);
                Debug.Log("enemybutton gen : " + buttonidx);
            }
            else return;
        }
        else
        {
            InputProcess(buttonidx);
        }
    }

    private void GiveButton(GameObject target)
    {
        // target (nearest Enemy)���� button����
        int randColor = Random.Range(0,3);
        int randAlphabet = Random.Range(0,3);
        // mapping 2D Array to 1D Array
        buttonidx = randAlphabet;
        nowButton = buttons[randAlphabet + randColor*3];

        enemyController.GenerateButton(nowButton);
        buttonON = true;
    }
    private void DeleteButton()
    {
        // Enemy�� ü�� ����
        enemyController.ChangeHealth(-1);
        buttonON = false;
        nowButton = null;
        enemyController.DeleteButton();

        // ���� �ʿ� ���� �� 
        // Update()���� ����ؼ� target�� �ٲ㼳���ϴϱ�
        if(enemyController.GetCurrentHealth() <= 0)
        {
            
        }
    }
    private void InputProcess(int buttonIndex)
    {
        // buttonIdx�� �´� �� ������ DeleteButton ȣ��
        switch (buttonIndex)
        {
            case 0: // if Button A
                if (Input.GetKeyDown(KeyCode.A)) DeleteButton();
                break;
            case 1: // if Button S
                if (Input.GetKeyDown(KeyCode.S)) DeleteButton();
                break;
            case 2: // if Button D
                if (Input.GetKeyDown(KeyCode.D)) DeleteButton();
                break;
        }
    }

}