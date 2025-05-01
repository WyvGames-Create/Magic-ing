using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<SpellSO> Spellbook;
    
    public bool SummonMagic(string element, string form)
    {
        if (element == null || form == null) return false;

        bool spellExists = false;
        foreach (SpellSO spell in Spellbook)
        {
            if (element.Equals(spell.element.id) && form.Equals(spell.form.id))
            {
                spellExists = true;
                CastSpell(spell.element, spell.form, spell.prefab);
                break;
            }
        }

        return spellExists;
    }

    private void CastSpell(ElementSO element, FormSO form, GameObject spellPrefab)
    {
        GameObject spellObject = Instantiate(spellPrefab);
        Projectile objScript = spellObject.GetComponent<Projectile>();
        objScript.element = element;
        objScript.form = form;
    }
}
