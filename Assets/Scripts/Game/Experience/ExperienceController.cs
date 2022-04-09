using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    public Sprite sprite;
    public int value;
    public Sprite[] tileSet;
    public GameObject experience;

    public ExperienceController enable()
    {
        gameObject.SetActive(true);
        return this;
    }

    public ExperienceController disable()
    {
        ExperienceCollection.remove(this);
        gameObject.SetActive(false);
        return this;
    }


}
