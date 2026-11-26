using UnityEngine;

public class ClassPractice : MonoBehaviour
{
    [ContextMenu("클래스 실습")]
    void ShowWeapom()
    {
        Weapon sword = new Weapon("낡은 검", 2);
        for (int i = 0; i < 3; i++)
        {
            if (sword.Use())
            {
                Debug.Log(sword.name + " 사용, 남은 내구도 " + sword.durability);
            }
            else
            {
                Debug.Log(sword.name + " 부서짐");
            }
        }

    }
}
