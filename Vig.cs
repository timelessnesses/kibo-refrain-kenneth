
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Linq;

namespace StorybrewScripts
{
    public class Vig : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            int EndTime = (int)(Beatmap.HitObjects.LastOrDefault()?.EndTime ?? AudioDuration);
            var vig = GetLayer("Vig").CreateSprite("sb/vig.png", OsbOrigin.Centre);
            var bitmap = GetMapsetBitmap("sb/vig.png");
            vig.Fade(-1000, 229346, 1, 1);
            vig.Scale(-1000, 480.0f / bitmap.Height);
            vig.Fade(229346, 229346, 1, 0);
        }
    }
}
