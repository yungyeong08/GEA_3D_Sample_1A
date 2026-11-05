using UnityEngine;

public class RewardCalc : MonoBehaviour
{
    public int PlayerSeconds = 3725;
    public int Gold = 1234;
    public int Members = 4;
    public int Kills = 7;
    public int ExpPerKill = 35;

    public int TotelDamage = 250;
    public int Hits = 20;
    public float ExpRate = 1.5f;
    [ContextMenu("정산")]
    void Settle()
    {
        int goldMembers = Gold / Members;
        int readerBonus = Gold % Members;
        Debug.Log("골드 분배: " + goldMembers + "리더 보너스: " + readerBonus);

        
    }
   
}
