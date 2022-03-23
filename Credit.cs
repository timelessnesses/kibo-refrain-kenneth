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
            var layer = GetLayer("Credit");
            var gd = layer.CreateSprite("sb/gds/" + author_name(Beatmap.ToString()) + ".png");
            var an_idiot = layer.CreateSprite("sb/gds/an idiot.png");
            var diff_by = layer.CreateSprite("sb/gds/Difficulty By_.png");
            var set_by = layer.CreateSprite("sb/gds/Mapset By_.png");
            var author = layer.CreateSprite("sb/gds/KennethBBG.png");
            var haha_totally_not_sponsorship_smiley_face_here = layer.CreateSprite("sb/gds/Storyboard By_.png");
            var hitsound_by = layer.CreateSprite("sb/gds/Hitsounded By_.png");
            var no = layer.CreateSprite("sb/gds/boobs.png");

            no.ScaleVec(0, new Vector2(0.5f, 0.5f));
            no.Fade(0, 1000, 0, 1);
            no.Move(OsbEasing.In, 0, 1000, new Vector2(360, 180), new Vector2(340, 200));
            no.Move(OsbEasing.Out, 1000, 25625, new Vector2(340, 200), new Vector2(300, 230));
            no.Fade(25600, 25625, 1, 0);
            //this works
            set_by.ScaleVec(0, new Vector2(0.5f, 0.5f));
            set_by.Move(OsbEasing.In, 0, 1000, new Vector2(80, 80), new Vector2(100, 90));
            set_by.Fade(OsbEasing.In, 0, 1000, 0, 1);
            set_by.Move(OsbEasing.In, 1000, 6250, new Vector2(100, 90), new Vector2(110, 100));
            set_by.Fade(OsbEasing.Out, 5250, 6250, 1, 0);
            //this works

            author.ScaleVec(0, new Vector2(0.4f, 0.4f));
            author.Move(OsbEasing.In, 0, 1000, new Vector2(590, 330), new Vector2(580, 340));
            author.Fade(OsbEasing.In, 0, 1000, 0, 1);
            author.Move(OsbEasing.In, 1000, 6250, new Vector2(580, 340), new Vector2(570, 350));
            author.Fade(OsbEasing.Out, 5250, 6250, 1, 0);
            //this works

            // --------------------------------------------------------

            diff_by.ScaleVec(6250, new Vector2(0.4f, 0.4f));
            diff_by.Move(OsbEasing.In, 6250, 7250, new Vector2(80, 80), new Vector2(100, 90));
            diff_by.Fade(OsbEasing.In, 6250, 7250, 0, 1);
            diff_by.Move(OsbEasing.In, 7250, 12500, new Vector2(100, 90), new Vector2(110, 100));
            diff_by.Fade(OsbEasing.Out, 11500, 12500, 1, 0);
            //this works

            gd.ScaleVec(6250, new Vector2(0.4f, 0.4f));
            gd.Move(OsbEasing.In, 6250, 7250, new Vector2(590, 330), new Vector2(580, 340));
            gd.Fade(OsbEasing.In, 6250, 7250, 0, 1);
            gd.Move(OsbEasing.In, 7250, 12500, new Vector2(580, 340), new Vector2(570, 350));
            gd.Fade(OsbEasing.Out, 11500, 12500, 1, 0);
            // this works

            // -----------------------------------------------------------------------------------

            hitsound_by.ScaleVec(12500, new Vector2(0.35f, 0.35f));
            hitsound_by.Move(OsbEasing.In, 12500, 13500, new Vector2(80, 80), new Vector2(90, 90));
            hitsound_by.Fade(OsbEasing.In, 12500, 13500, 0, 1);
            hitsound_by.Move(OsbEasing.In, 13600, 18750, new Vector2(90, 90), new Vector2(100, 100));
            hitsound_by.Fade(OsbEasing.Out, 17750, 18750, 1, 0);
            //this works

            author.ScaleVec(12500, new Vector2(0.4f, 0.4f));
            author.Move(OsbEasing.In, 12500, 13500, new Vector2(590, 330), new Vector2(580, 340));
            author.Fade(OsbEasing.In, 12500, 13500, 0, 1);
            author.Move(OsbEasing.In, 13600, 18750, new Vector2(580, 340), new Vector2(570, 350));
            author.Fade(OsbEasing.Out, 17750, 18750, 1, 0);
            // this works

            // -----------------------------------------------------------------------------------

            haha_totally_not_sponsorship_smiley_face_here.ScaleVec(18750, new Vector2(0.35f, 0.35f));
            haha_totally_not_sponsorship_smiley_face_here.Move(OsbEasing.In, 18750, 19750, new Vector2(80, 80), new Vector2(90, 90));
            haha_totally_not_sponsorship_smiley_face_here.Fade(OsbEasing.In, 18750, 19750, 0, 1);
            haha_totally_not_sponsorship_smiley_face_here.Move(OsbEasing.In, 19750, 25625, new Vector2(90, 90), new Vector2(100, 100));
            haha_totally_not_sponsorship_smiley_face_here.Fade(OsbEasing.Out, 24625, 25625, 1, 0);
            //this works

            an_idiot.ScaleVec(-2000, new Vector2(0.4f, 0.4f));
            an_idiot.Move(OsbEasing.In, 18750, 19750, new Vector2(590, 330), new Vector2(580, 340));
            an_idiot.Fade(OsbEasing.In, 18750, 19750, 0, 1);
            an_idiot.Move(OsbEasing.In, 19750, 25625, new Vector2(580, 340), new Vector2(570, 350));
            an_idiot.Fade(OsbEasing.Out, 24625, 25625, 1, 0);
            // this works
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
