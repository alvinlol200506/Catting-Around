using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private float time = 60f; // default 1 minute

    private float timer;
    private bool timerActive = false;

    public int health;
    public int enemyHealth;
    public int maxHealth=10;
    public int EnemyMaxHealth=10;
    public int CatnipMeter = 0;
    public bool wet;
    public Image healthbar;
    public Image enemyHealthbar;
    public GameObject QTE;
    RectTransform fillrect;
    RectTransform enemyFillrect;
    [SerializeField] EndingImagesSO es;

    public TextMeshProUGUI DisplayTime;

    private bool isPlayerInTrigger = false; // Add this field

    public void HealthEdit(int x, string sumber)
    {
        health += x;
        if (health <= 0)
        {
            Debug.Log("death");
            es.ending = sumber;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        updatebar();
    }
    public void EnemyHealthEdit(int x)
    {
        enemyHealth += x;
        if (enemyHealth <= 0)
        {
            QTE.SetActive(false);

        }
        
        updateEnemyBar();
    }

    void Start()
    {
        fillrect = healthbar.rectTransform;
        enemyFillrect = enemyHealthbar.rectTransform;
        health = maxHealth;
        enemyHealth = EnemyMaxHealth;
        updatebar();
        timer = time;
        timerActive = true;
    }

    void updatebar() { 
        float ratio = (float)health / maxHealth;
        var size = fillrect.sizeDelta;
        size.x = ratio * 110f;
        fillrect.sizeDelta = size;
    }

    void updateEnemyBar()
    {
        float ratio = (float)enemyHealth / EnemyMaxHealth;
        var size = enemyFillrect.sizeDelta;
        size.x = ratio * 110f;
        enemyFillrect.sizeDelta = size;
    }

    // These methods should be on the trigger collider object, or you can move them here if LogicScript is attached to the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject has the "Player" tag
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Max(timer, 0f);

            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            DisplayTime.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));

            if (timer <= 0f)
            {
                timerActive = false;
                end();
            }
        }
    }

    private void end()
    {
        if (isPlayerInTrigger)
        {
            es.ending = "Missing";
        }
        else
        {
            es.ending = "Good Boy";
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }




    


}
