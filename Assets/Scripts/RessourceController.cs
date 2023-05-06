using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceController
{
    private const int MIN_SPAWN_NUM = 10;

    public Ressources CreateRessources(int mineralBonus, int foodBonus, int goldBonus)
    {
        return new Ressources(GetResourceAmount(mineralBonus), GetResourceAmount(foodBonus), GetResourceAmount(goldBonus));
    }

    private int GetResourceAmount(int bonus)
    {
        if (Random.Range(0, 101) <= ((int) + bonus))
        {
            return MIN_SPAWN_NUM + bonus;
        }

        return MIN_SPAWN_NUM;
    }
}
