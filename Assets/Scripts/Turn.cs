using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Turn {
    private List<Rune> runesAdded = new List<Rune>();
    public Ritual ritualCast = null;
    public Player target = null;

    public void AddRune(Rune rune)
    {
        if (runesAdded.Count < 2)
        {
            runesAdded.Add(rune);
        }
    }

    public void RemoveRune()
    {
        if (runesAdded.Count > 0)
        {
            runesAdded.RemoveAt(runesAdded.Count - 1);
        }
    }

    public List<Rune> GetRunes()
    {
        return runesAdded;
    }
}
