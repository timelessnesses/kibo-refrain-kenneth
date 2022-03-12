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
    public class Particles : StoryboardObjectGenerator
    {
        [Configurable]
        public int particles_count = 69;

        public override void Generate()
        {
            var times = new Dictionary<int, int>();
            times[59113] = 87020;
            times[109346] = 131672;
            times[188881] = 228648;
            foreach (var time in times)
            {
                Generates(time.Key, time.Value);
            }
        }
        public void Generates(int StartTime, int EndTime)
        {
            var layer = GetLayer("subtitle");
            StartTime -= 1000;
            EndTime += 4000;
            var colors = new Dictionary<string, Color4>();
            colors["Cyan"] = Color4.Cyan;
            colors["Pink"] = Color4.Pink;
            for (var count = 0; count < particles_count; count++)
            {
                var particle = layer.CreateSprite("sb/box_uwu.png", OsbOrigin.Centre);
                particle.Scale(OsbEasing.None, StartTime, EndTime, Random(0.3, 0.9), Random(0.3, 0.9));
                particle.Fade(OsbEasing.None, StartTime, EndTime + 500, 0.3, 1);
                var posx = Random(-300, 760);
                var posy = Random(600, 2000);
                particle.Move(OsbEasing.None, StartTime, EndTime + Random(100, 5000), new Vector2(posx, posy), new Vector2(posx, -690));
                var color = Random_Dict(colors);
                particle.Color(StartTime, color);
            }
        }
        public Color4 Random_Dict(Dictionary<string, Color4> colors)
        {
            var rand = new Random();
            var keys = colors.Keys.ToList();
            var random_key = keys[rand.Next(0, keys.Count)];
            return colors[random_key];
        }
    }
}
