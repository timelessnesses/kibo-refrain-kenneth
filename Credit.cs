using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
namespace StorybrewScripts
{
    public class Credit : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            string author = "";
            if (author_name(Beatmap.ToString()) == "")
            {

                author = "KennethBBG"; //force

            }
            else
            {
                author = author_name(Beatmap.ToString());
            }

            var sprite = GetLayer("").CreateSprite("sb/gds/" + author + ".png", OsbOrigin.Centre);
        }

        public string author_name(string difficulty_name)
        {
            string[] gds = { "Narcissu" };

            if (gds.Contains(difficulty_name))
            {
                return "Narcissu";
            }
            else
            {
                return "";
            }
        }
    }
}
