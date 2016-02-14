using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Ritual
{

    public static readonly Ritual FIREBALL = new Ritual("Fireball: AA A", 8, new Rune[] { Rune.a, Rune.a, Rune.a}, () => { RitualEffect.instance.FireballEffect(); }, "FireballAnimation");
    public static readonly Ritual LIGHTSHIELD = new Ritual("Light Shield: AA B", 6, new Rune[] { Rune.a, Rune.a,Rune.b}, () => { RitualEffect.instance.ShieldEffect(); }, "ShieldAnimation");
    public static readonly Ritual PARALYSE = new Ritual("Paralyse: AA C", 4, new Rune[] { Rune.a, Rune.a,Rune.c }, () => { RitualEffect.instance.ParalyseEffect(); }, "ParalyseAnimation");
    public static readonly Ritual HEALINGWATER = new Ritual("Healing Water: AA D", 10, new Rune[] { Rune.a, Rune.a,Rune.d }, () => { RitualEffect.instance.HealingWaterEffect(); }, "HealingWaterAnimation");
    public static readonly Ritual DISENCHANT = new Ritual("Disenchant: AA EE", 13, new Rune[] { Rune.a, Rune.a,Rune.e,Rune.e}, () => { RitualEffect.instance.DisenchantEffect(); }, "DisenchantAnimation");
    public static readonly Ritual CONFUSION = new Ritual("Confusion: AA EE A", 12, new Rune[] { Rune.a, Rune.a,Rune.e,Rune.e,Rune.a }, () => { RitualEffect.instance.ConfuseEffect(); }, "ConfuseAnimation");
    public static readonly Ritual MIRROR = new Ritual("Mirror: AA EE B", 3, new Rune[] { Rune.a, Rune.a,Rune.e,Rune.e,Rune.b }, () => { RitualEffect.instance.MirrorEffect(); }, "MirrorAnimation");

    public static readonly Ritual MAGICBOMB = new Ritual("Magic Bomb: AA EE C", 11, new Rune[] { Rune.a, Rune.a,Rune.e,Rune.e,Rune.c }, () => { RitualEffect.instance.MagicBombEffect(); }, "MagicBombAnimation");
    public static readonly Ritual FREEZE = new Ritual("Freeze: AA FF EA", 1, new Rune[] { Rune.a, Rune.a,Rune.f,Rune.f,Rune.e,Rune.a }, () => { RitualEffect.instance.FreezeEffect(); }, "FreezeAnimation");
    public static readonly Ritual POWERSURGE = new Ritual("Power Surge: AA FF EB", 5, new Rune[] { Rune.a, Rune.a,Rune.f,Rune.f,Rune.e,Rune.b }, () => { RitualEffect.instance.PowerSurgeEffect(); }, "PowerSurgeAnimation");
    public static readonly Ritual COMPANION = new Ritual("Companion: AA FF EC", 2, new Rune[] { Rune.a, Rune.a,Rune.f,Rune.f,Rune.e,Rune.c }, () => { RitualEffect.instance.CompanionEffect(); ; }, "CompanionAnimation");
    public static readonly Ritual FIRECANNON = new Ritual("Fire Cannon: AA FF ED", 7, new Rune[] { Rune.a, Rune.a,Rune.f,Rune.f,Rune.e,Rune.d }, () => { RitualEffect.instance.FireCannonEffect(); }, "FireCannonAnimation");
    public static readonly Ritual DRAIN = new Ritual("Drain: AA FF EE", 9, new Rune[] { Rune.a, Rune.a,Rune.f,Rune.f,Rune.e,Rune.e }, () => { RitualEffect.instance.DrainEffect(); }, "DrainAnimation");




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
            yield return HEALINGWATER;
            yield return DISENCHANT;
            yield return CONFUSION;
            yield return MIRROR;

            yield return MAGICBOMB;
            yield return FREEZE;
            yield return POWERSURGE;
            yield return COMPANION;
            yield return FIRECANNON;
            yield return DRAIN;


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