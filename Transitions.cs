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
    public class Transitions : StoryboardObjectGenerator
    {
        [Configurable]
        public int Start = 0;

        [Configurable]
        public int End = 0;

        [Configurable]
        public Color4 Color = Color4.DimGray;

        [Configurable]
        public int Lines = 10;
        public override void Generate()
        {
            GenerateLines();
        }

        public void GenerateLines()
        {
            var easings = new List<OsbEasing>();
            easings.Add(OsbEasing.OutExpo);
            easings.Add(OsbEasing.InExpo);
            easings.Add(OsbEasing.OutSine);
            var layer = GetLayer("Transitions");
            var white = layer.CreateSprite("sb/white.png", OsbOrigin.Centre);
            white.Scale(Start, 500.0f / GetMapsetBitmap("sb/white.png").Height);
            white.Fade(Start, 1);
            var random = new Random();
            var randomed = easings[random.Next(easings.Count)];
            white.MoveY(randomed, Start, End, -500, 234);
            white.Fade(End, End + 500, 1, 0);
        }
    }
}
