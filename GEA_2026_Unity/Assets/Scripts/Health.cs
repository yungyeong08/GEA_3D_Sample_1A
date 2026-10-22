using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHp = 3;
    public int currentHp;
    public Slider hpSlider;

    public static int killCount;
    public float invincibleTime = 0f;
    float lastHitTime = -999f;
    public GameObject dropPrefab;
    public float dropChance = 0.3f;
    public GameObject hitEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        UpdateBar();
        
    }

    public void TakeDamage(int damage)
    {
        if (currentHp <= 0) return;
        if (Time.time < lastHitTime + invincibleTime) return;
        lastHitTime = Time.time;

        currentHp -= damage;
        Debug.Log(name + " HP: " + currentHp);
        UpdateBar();

        Vector3 hitpos = transform.position + Vector3.up;
        if (hitEffect != null)
            Instantiate(hitEffect, hitpos, Quaternion.identity);

        if (currentHp <= 0) Die();
        else Blink();
    }

    void UpdateBar()
    {
        Debug.Log(name + " Current HP: " + currentHp + " / Max HP: " + maxHp);
       
        if (hpSlider != null)
            hpSlider.value = (float)currentHp / maxHp;
    }

    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        UpdateBar();
    }

    void Die()
    {
        if (CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
        else if(dropPrefab != null && Random.value < dropChance)
        {
            killCount++;
            Vector3 pos = transform.position + Vector3.up * 0.5f;
            Instantiate(dropPrefab, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Blink()
    {
        SetVisble(false);
        Invoke(nameof(ShowAgain), 0.1f);
    }

    void ShowAgain()
    {
        SetVisble(true);
    }

    void SetVisble(bool on)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = on;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
