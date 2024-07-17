using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;

    public void ShowDamageText(float damageAmount, Vector2 position)
    {
        GameObject damageTextObject = Instantiate(damageTextPrefab, position, Quaternion.identity);
        DamageText damageText = damageTextObject.GetComponent<DamageText>();
        damageText.SetDamage(damageAmount);
    }
}
