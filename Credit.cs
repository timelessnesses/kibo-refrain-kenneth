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

            var layer = GetLayer("Credits");
            var box1 = layer.CreateSprite("sb/white.png");
            var box2 = layer.CreateSprite("sb/white.png");
            var white = layer.CreateSprite("sb/white.png");
            box1.Color(OsbEasing.None, -500, 3299, new Color4(0, 0, 0, 0), new Color4(0, 0, 0, 0)); // black
            box2.Color(OsbEasing.None, -500, 3299, new Color4(0, 0, 0, 0), new Color4(0, 0, 0, 0)); // black box (real)

        }

        public string author_name(string difficulty_name)
        {
            string[] gds = { "Narcissu" };

            if (gds.Contains(difficulty_name))
            {
                return difficulty_name.Split("'s".ToCharArray())[0];
            }
            else
            {
                return "KennethBBG";
            }
        }
    }
}
