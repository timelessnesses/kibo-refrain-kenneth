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

            var beatmap_set = GetLayer("").CreateSprite("sb/gds/Beatmap Set_.png", OsbOrigin.Centre);
            beatmap_set.Move(OsbEasing.Out, 0, 2941, new Vector2(-280, 80), new Vector2(110, 80));
            beatmap_set.Fade(0, 0, 0, 1);
            beatmap_set.Fade(2951, 3299, 1, 0);
            beatmap_set.Scale(0, 0.6);
            var set_owner = GetLayer("").CreateSprite("sb/gds/" + "KennethBBG" + ".png", OsbOrigin.Centre);
            set_owner.Move(OsbEasing.Out, 0, 2951, new Vector2(-300, 80), new Vector2(400, 80));
            set_owner.Fade(0, 0, 0, 1);
            set_owner.Fade(2951, 3299, 1, 0);

            var difficulty_by = GetLayer("").CreateSprite("sb/gds/Difficulty By_.png", OsbOrigin.Centre);
            difficulty_by.Move(OsbEasing.Out, 0, 2941, new Vector2(-300, 180), new Vector2(110, 180));
            difficulty_by.Fade(0, 0, 0, 1);
            difficulty_by.Fade(2951, 3299, 1, 0);
            difficulty_by.Scale(0, 0.6);
            var gd = GetLayer("").CreateSprite("sb/gds/" + author + ".png", OsbOrigin.Centre);
            gd.Move(OsbEasing.Out, 0, 2951, new Vector2(-280, 180), new Vector2(400, 180));
            gd.Fade(0, 0, 0, 1);
            gd.Fade(2951, 3299, 1, 0);

            var storyboard_by = GetLayer("").CreateSprite("sb/gds/Storyboard By_ .png", OsbOrigin.Centre);
            storyboard_by.Move(OsbEasing.Out, 0, 2941, new Vector2(-300, 360), new Vector2(150, 360));
            storyboard_by.Fade(0, 0, 0, 1);
            storyboard_by.Fade(2951, 3299, 1, 0);
            storyboard_by.Scale(0, 0.6);
            var an_idiot = GetLayer("").CreateSprite("sb/gds/" + "Whistle_Python" + ".png", OsbOrigin.Centre);
            an_idiot.Move(OsbEasing.Out, 0, 2951, new Vector2(-300, 320), new Vector2(525, 320));
            an_idiot.Fade(0, 0, 0, 1);
            an_idiot.Fade(2951, 3299, 1, 0);
            an_idiot.Scale(0, 0.5);

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
                return "";
            }
        }
    }
}
