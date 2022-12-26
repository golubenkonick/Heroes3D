using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Power { get; set; }
    public int Knowledge { get; set; } 
    public SecondarySkill[] SecondarySkills { get; set; } = new SecondarySkill[10];

    public RightHand RightHand { get; set; }
    public LeftHand LeftHand { get; set; }

    public Helm Helm { get; set; }

    public Cape Cape { get; set; }
    public Necklace Necklace { get; set; }
    public Torso Torso { get; set; }
    public Ring Ring { get; set; }
    public Feet Feet { get; set; }
    public Miscellaneous[] Miscellaneous { get; set; } = new Miscellaneous[5];

    public Ballista Ballista { get; set; }

    public AmmoCart AmmoCart { get; set; }  

    public FirstAidTent FirstAidTent { get; set; }

    public Catapult Catapult { get; set; }  

    public SpellBook SpellBook { get; set; }    

    Artifact[] Backpack { get; set; } = new Artifact[64]; // unused artifacts


}
