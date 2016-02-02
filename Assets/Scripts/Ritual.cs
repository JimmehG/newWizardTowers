using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Ritual
{

    public static readonly Ritual FIREBALL = new Ritual("Fireball", 8, new Rune[] { Rune.a, Rune.f }, () => { RitualEffect.instance.FireballEffect(); }, "FireballAnimation");
    public static readonly Ritual LIGHTSHIELD = new Ritual("Light Shield", 6, new Rune[] { Rune.a, Rune.f }, () => { RitualEffect.instance.ShieldEffect(); }, "ShieldAnimation");
    public static readonly Ritual PARALYSE = new Ritual("Paralyse", 4, new Rune[] { Rune.a, Rune.f }, () => { RitualEffect.instance.ParalyseEffect(); }, "ParalyseAnimation");
    public static readonly Ritual HEALINGWATER = new Ritual("Healing Water", 10, new Rune[] { Rune.a, Rune.f }, () => { RitualEffect.instance.HealingWaterEffect(); }, "HealingWaterAnimation");
    public static readonly Ritual CONFUSION = new Ritual("Confusion", 12, new Rune[] { Rune.a, Rune.f }, () => { RitualEffect.instance.ConfuseEffect(); }, "ConfuseAnimation");


    private readonly string name;
    private readonly int priority;
    private readonly Rune[] runes;
    private readonly Action effect;
    private readonly string animation;

    Ritual(string name, int priority, Rune[] runes, Action effect, string animation)
    {
        this.name = name;
        this.priority = priority;
        this.runes = runes;
        this.effect = effect;
        this.animation = animation;
    }

    public static IEnumerable<Ritual> Values
    {
        get
        {
            yield return FIREBALL;
            yield return LIGHTSHIELD;
            yield return PARALYSE;
            yield return CONFUSION;
        }
    }

    public string GetName()
    {
        return name;
    }

    public int GetPriority()
    {
        return priority;
    }

    public Rune[] GetRunes()
    {
        return runes;
    }

    public void CastEffect()
    {
        effect.Invoke();
    }

    public string GetAnimation()
    {
        return animation;
    }

    public bool Castable(Rune[] bucket)
    {
        foreach (Rune r in System.Enum.GetValues(typeof(Rune)))
        {
            int min = RuneCount(runes, r);
            if (RuneCount(bucket, r) < min)
            {
                return false;
            }
        }

        return true;
    }

    private int RuneCount(Rune[] runes, Rune rune)
    {
        int count = 0;
        foreach (Rune r in runes)
        {
            if (r == rune)
            {
                count++;
            }
        }

        return count;
    }
}