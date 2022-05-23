using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    //cyclops
    public static bool BeatCyclopsGame { get; set; } = false;
    public static bool CyclopsTalk { get; set; } = false;
    //Calypso
    public static bool BeatCalypsoGame { get; set; } = false;
    public static bool CalypsoTalk { get; set; } = false;
    //Ithaka
    public static bool BeatIthakaGame { get; set; } = false;
    public static bool TelemachusTalk { get; set; } = false;
    public static int AreasUnlocked { get; set; } = 0;
}
