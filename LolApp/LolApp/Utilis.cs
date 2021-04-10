﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp
{
    public class Utilis
    {
        public static string GetSpell(int id)
        {
            string spell = Config.SummonerSpellsIconUrl;
            switch (id)
            {
                case 1:
                    return spell += "SummonerBoost.png";

                case 21:
                    return spell += "SummonerBarrier.png";

                case 14:
                    return spell += "SummonerDot.png";

                case 3:
                    return spell += "SummonerExhaust.png";

                case 4:
                    return spell += "SummonerFlash.png";

                case 6:
                    return spell += "SummonerHaste.png";

                case 7:
                    return spell += "SummonerHeal.png";

                case 13:
                    return spell += "SummonerMana.png";

                case 30:
                    return spell += "SummonerPoroRecall.png";

                case 31:
                    return spell += "SummonerPoroThrow.png";

                case 11:
                    return spell += "SummonerSmite.png";
                case 39:
                    return spell += "SummonerSnowURFSnowball_Mark.png";
                case 32:
                    return spell += "SummonerSnowball.png";
                case 12:
                    return spell += "SummonerTeleport.png";
            }

            return spell;
        }


    }
}
