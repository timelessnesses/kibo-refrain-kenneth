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
    public class GlowTime : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            List<int> times = "207020 208416 160974 77253 78648 85625 127486 160974 128881 98183 155393 177718 47951 25625 36788 59113 71497 74288 75858 81439 87020 109346 121730 124520 126090 131672 144230 149811 166555 188881 201265 204055 205625 211206 216788 222369 227951".Split(" ".ToCharArray()).Select(int.Parse).ToList();
            foreach (var time in times)
            {
                try
                {
                    System.Convert.ToInt32(time);
                }
                catch
                {
                    continue; // white space or smth
                }
                var glow = GetLayer("").CreateSprite("sb/glow.png");
                OsuHitObject hitobject = null;
                foreach (var hitobject_ in Beatmap.HitObjects)
                {
                    if (hitobject_.StartTime == time)
                    {
                        hitobject = hitobject_;
                        break;
                    }
                }
                if (hitobject != null)
                {
                    glow.Color(OsbEasing.None, time, time, hitobject.Color, hitobject.Color);
                }
                else
                {
                    Color4[] colors = {
                        Color4.AliceBlue,
                        Color4.Pink,
                        Color4.White
                    };
                    var color = Color_Random(colors);
                    glow.Color(OsbEasing.None, time, time, color, color);
                }
                glow.Fade(OsbEasing.Out, time, time + ((180509 - 180160) * 2), 1, 0);
            }
        }

        private Color4 Color_Random(Color4[] stuff)
        {
            Random random = new Random();
            var random_element = stuff[random.Next(0, stuff.Length)];
            return random_element;
        }
    }
}
