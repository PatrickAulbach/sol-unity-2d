using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] RessourceController ressourceController;
    private Ressources ressources;
    void Start()
    {
        ressources = CreateRessources();
    }

    private Ressources CreateRessources()
    {
        switch (name.ToLower())
        {
            case "mercury":
            case "venus":
            case "earth":
            case "mars":
            case "moon":
            case "asteroid":
                return ressourceController.CreateRessources(20, 15, 0);
            case "jupiter":
            case "uranus":
            case "neptune":
            case "saturn":
                return ressourceController.CreateRessources(0, -5, 20);
            case "sun":
                return ressourceController.CreateRessources(0, -10, 0);
            case "nebula":
                return ressourceController.CreateRessources(10, 0, 10);
            default:
                return new Ressources();
        }
    }

}
