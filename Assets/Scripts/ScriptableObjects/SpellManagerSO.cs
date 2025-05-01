using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellManager", menuName = "ScriptableObjects/SpellManagerSO")]
public class SpellManagerSO : ScriptableObject
{
    public List<SpellSO> Spellbook;
    
    private SpellSO FindSpell(string element, string form)
    {
        if (element == null || form == null)
        {
            Debug.Log("Cannot find with null parameters");
            return null;
        }

        foreach (SpellSO spell in Spellbook)
        {
            if (element.Equals(spell.element.id) && form.Equals(spell.form.id))
            {
                return spell;
            }
        }

        Debug.Log("Spell does not exist in the Spellbook");
        return null;
    }

    public void CastSpell(string element, string form, Vector2 position, Quaternion rotation)
    {
        SpellSO spell = FindSpell(element, form);

        GameObject projectile = Instantiate(spell.prefab, position, rotation);
        Projectile objScript = projectile.GetComponent<Projectile>();
        objScript.element = spell.element;
        objScript.form = spell.form;
    }
}
