﻿using UnityEngine;
using System.Collections;

public class RitualEffect : MonoBehaviour
{

    public static RitualEffect instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public RitualEffect()
    {
    }


    public void FireballEffect()
    {
        Player source = GameController.instance.currentCaster;
        try
        {
            ChooseTarget(source);
            Player target = source.getTurn().target;

            if (!target.currentEffects.Contains(Player.StatusEffect.Shield))
            {
                target.addHealth(-10);
            }
        }
        finally
        {
            source.castingEffect = false;
        }
    }

    public void ShieldEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.Shield);

        source.castingEffect = false;
    }

    public void ParalyseEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.Paralyse);

        source.castingEffect = false;
    }

    public void HealingWaterEffect()
    {
        Player source = GameController.instance.currentCaster;
        try
        {
            source.addHealth(10);
           

        }
        finally
        {
            source.castingEffect = false;
        }
    
    }

    public void DisenchantEffect()
    {



        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.HealingWater);

        source.castingEffect = false;
    }



    public void ConfuseEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.Confuse);

        source.castingEffect = false;
    }

    public void MirrorEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.Shield);

        source.castingEffect = false;
    }

    public void MagicBombEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        




    }

    public void FreezeEffect()
    {
        

        Player source = GameController.instance.currentCaster;

        ChooseTarget(source);
        Player target = source.getTurn().target;

        
        
        //target.enabled = false;

        


        source.castingEffect = false;


    }

    public void PowerSurgeEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.Shield);

        source.castingEffect = false;
    }


    public void CompanionEffect()
    {
        Player source = GameController.instance.currentCaster;
        ChooseTarget(source);
        Player target = source.getTurn().target;

        target.addStatus(Player.StatusEffect.Shield);

        source.castingEffect = false;
    }


    public void FireCannonEffect()
    {
        Player source = GameController.instance.currentCaster;

        try
        {
            ChooseTarget(source);
            Player target = source.getTurn().target;

            if (!target.currentEffects.Contains(Player.StatusEffect.Shield))
            {
                target.addHealth(-20);
            }
        }
        finally
        {
            source.castingEffect = false;
        }

        source.castingEffect = false;
    }


    public void DrainEffect()
    {
        Player source = GameController.instance.currentCaster;
        try
        {
            ChooseTarget(source);
            Player target = source.getTurn().target;

            if (!target.currentEffects.Contains(Player.StatusEffect.Shield))
            {
                target.addHealth(-10);
            }
        }
        finally
        {
            source.addHealth(10);
            source.castingEffect = false;
        }

       
        source.castingEffect = false;
    }
                 




    static void ChooseTarget(Player source)
    {
        Player target = source.getTurn().target;

        if (source.currentEffects.Contains(Player.StatusEffect.Confuse))
        {
            if (UnityEngine.Random.value > 0.5f)
            {
                if (target == GameController.instance.player1) { target = GameController.instance.player2; }
                else { target = GameController.instance.player1; }

                source.getTurn().target = target;
            }
        }
    }

}
