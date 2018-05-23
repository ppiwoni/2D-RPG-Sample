using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterUIDamage : MonoBehaviour
{

    #region Singleton
    public static CharacterUIDamage instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Text damageTextPrefab;
    Color32 damageColor;

    public void ShowDamage(string damage, Transform target)
    {
        if (target.tag == "Player")
        { 
            damageColor = new Color32(203, 186, 26, 255);
        }
        else if (target.tag == "Enemy")
        {
            damageColor = new Color32(203, 85, 26, 255);
        }

        var damageText = Instantiate(damageTextPrefab, target.position, Quaternion.identity, transform);
        damageText.text = damage;
        damageText.color = damageColor;
        damageText.GetComponent<Rigidbody2D>().velocity = new Vector2(target.localScale.x * -5, 5);
        Destroy(damageText.gameObject, 0.5f);

    }

  
}
