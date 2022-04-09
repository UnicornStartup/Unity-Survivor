using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExperienceCollection : MonoBehaviour
{
    public static List<ExperienceController> bullets = new List<ExperienceController>();
    public static List<ExperienceController> bulletsDisabled = new List<ExperienceController>();

    public static ExperienceController getDisabledBullet()
    {
        ExperienceController experienceController = bulletsDisabled.FirstOrDefault();
        if (experienceController != null) bulletsDisabled.Remove(experienceController);
        return experienceController;
    }
    public static void add(ExperienceController experienceController)
    {
        bullets.Add(experienceController);
    }
    public static void remove(ExperienceController experienceController)
    {
        bullets.Remove(experienceController);
        bulletsDisabled.Add(experienceController);
    }
}
