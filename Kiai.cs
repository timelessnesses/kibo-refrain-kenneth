using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Linq;
using System.Collections.Generic;

namespace StorybrewScripts
{
    public class Kiai : StoryboardObjectGenerator
    {

        public override void Generate()
        {
            var times = new Dictionary<int, int>();
            times[59113] = 87020;
            times[109346] = 131672;
            times[188881] = 227951;
            foreach (var time in times)
            {
                var boobs_real = GetLayer("kiai :dies:").CreateSprite("weeeeebs.jpg");
                ScaleToBeat(time.Key, time.Value, boobs_real);
                boobs_real.Fade(time.Key, time.Key, 1, 1);
                boobs_real.Fade(time.Value, time.Value, 0, 0);
            }
        }
        public void ScaleToBeat(int time, int end, OsbSprite bg)
        {
            for (var i = time; i < end; i += (180509 - 180160))
            {
                bg.Scale(OsbEasing.OutExpo, i, i + (180509 - 180160) - 1, 475.0f / GetMapsetBitmap("weeeeebs.jpg").Height, 480.0f / GetMapsetBitmap("weeeeebs.jpg").Height);
            }
        }
    }
}