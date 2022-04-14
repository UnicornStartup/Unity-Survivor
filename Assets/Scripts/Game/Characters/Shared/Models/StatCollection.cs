using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class StatCollection
{
    public List<Stat> stats = new List<Stat>();

    public float getvalue(StatType type)
    {
        return this.stats.Single(stat => stat.type == type).value;
    }

    public Stat getStat(StatType type)
    {
        return this.stats.Single(stat => stat.type == type);
    }

    public void addStat(StatType type, float value)
    {
        //Image image = Resources.LoadAll<Image>("Icons/Stats")[(int)type];
        this.stats.Add(new Stat(type, null, value));
    }
}
