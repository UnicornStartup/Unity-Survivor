using UnityEngine;

public class ExperienceSpawner : MonoBehaviour
{
    public GameObject spawn(Vector3 position)
    {
        ExperienceController experience = getBullet(position);
        ExperienceCollection.add(experience);
        return experience.gameObject;
    }

    public ExperienceController getBullet(Vector3 position)
    {
        ExperienceController experience = ExperienceCollection.getDisabledBullet();
        if (experience == null)
        {
            return instantiateBullet(position);
        }
        experience = new ExperienceBuilder(experience.gameObject)
            .setPosition(position)
            .setValue(12)
            .build()
            .enable();

        return experience;
    }
    public ExperienceController instantiateBullet(Vector3 position)
    {
        ExperienceController experience = new ExperienceBuilder()
            .setPosition(position)
            .setSprite("exp")
            .setValue(12)
            .build()
            .enable();

        return experience;
    }
}
