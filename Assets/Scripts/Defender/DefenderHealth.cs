using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefenderHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float flashSpeed = 5f;
    [SerializeField] private Image damageImage;
    [SerializeField] private Color flashColor = new Color (1f, 0f, 0f, 0.1f);
    private int currentHealth;
    private int startingHealth = 100;
    private bool damaged;
    private bool isDead;

    void Awake ()
    {

        
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    private void FixedUpdate ()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

    }

    private void Death ()
    {
        isDead = true;
        //animator.SetTrigger ("Die");
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        SceneManager.LoadScene (0);
    }
}