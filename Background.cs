using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Linq;
using System.Collections.Generic;
namespace StorybrewScripts
{
    public class Background : StoryboardObjectGenerator
    {
        [Configurable]
        public string BackgroundPath = "sb/boobs.png";

        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public double Opacity = 0.2;

        public override void Generate()
        {
            if (StartTime == EndTime) EndTime = (int)(Beatmap.HitObjects.LastOrDefault()?.EndTime ?? AudioDuration);

            var bitmap = GetMapsetBitmap(BackgroundPath);
            var bg = GetLayer("").CreateSprite(BackgroundPath, OsbOrigin.Centre);
            bg.Scale(StartTime, 480.0f / bitmap.Height);
            bg.Fade(StartTime - 500, StartTime, 0, Opacity);
            var times = new List<int>();
            times.Add(59113);
            times.Add(109346);
            times.Add(188881);
            times.Add(144230);
            times.Add(25625);
            foreach (var time in times)
            {
                FlashBang(time, bg);
            }
            bg.Fade(227951, 0);
            var times_ = new Dictionary<int, int>();
            times_[25625] = 36788;
            times_[59113] = 87020;
            times_[109346] = 131672;
            times_[188881] = 222369;
            times_[144230] = 166555;
            foreach (var time in times_)
            {
                ScaleToBeat(time.Key, time.Value, bg);
            }
            var times__ = new Dictionary<int, int>();

            times__[59113] = 87020;
            times__[109346] = 131672;
            times__[188881] = 227951;
            foreach (var time in times__)
            {
                bg.Fade(time.Key, time.Key, 0, 0);
                bg.Fade(time.Value, time.Value, 1, 1);
            }
        }
        public void FlashBang(int StartTime, OsbSprite bg)
        {
            ;
        }
        public void ScaleToBeat(int time, int end, OsbSprite bg)
        {
            for (var i = time; i < end; i += (180509 - 180160))
            {
                bg.Scale(OsbEasing.OutExpo, i, i + (180509 - 180160) - 1, 475.0f / GetMapsetBitmap(BackgroundPath).Height, 480.0f / GetMapsetBitmap(BackgroundPath).Height);
            }
        }
    }
}
