using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Collections.Generic;
namespace StorybrewScripts
{
    public class LineOverlay : StoryboardObjectGenerator
    {

        [Configurable]
        public int BeatDivisor = 1;

        [Configurable]
        public int FadeDuration = 200;

        [Configurable]
        public string SpritePath = "sb/bar.png";

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public string CirclePath = "sb/circle.png";

        public override void Generate()
        {
            var times = new Dictionary<int, int>();
            times[59113] = 87020;
            times[109346] = 131672;
            times[188881] = 222369;
            foreach (var time in times)
            {
                GenerateX(time.Key, time.Value);
            }
            int[] time_ = { 59113, 71497, 75858, 81439, 109346, 121730, 126090, 166555, 188881, 201265, 211206, 205625, 211206, 216788, 222369 };
            foreach (var time in time_)
            {
                GenerateY_Special(time);
            }

        }

        public void GenerateX(int StartTime, int EndTime)
        {
            var hitobjectLayer = GetLayer("");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) &&
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;

                var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Fade(OsbEasing.None, hitobject.StartTime - FadeDuration, hitobject.StartTime - 200, 0, 1);
                hSprite.ScaleVec(OsbEasing.In, hitobject.StartTime - FadeDuration, hitobject.StartTime, new OpenTK.Vector2((int)0, (int)0), new OpenTK.Vector2((int)SpriteScale, 1000));
                hSprite.ScaleVec(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeDuration, new OpenTK.Vector2((int)SpriteScale, 1000), new OpenTK.Vector2(0, 1000));
                hSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeDuration, 1, 0);
                hSprite.Additive(hitobject.StartTime, hitobject.EndTime + FadeDuration);
                hSprite.Color(hitobject.StartTime, hitobject.Color);

                if (hitobject is OsuSlider)
                {
                    hSprite.MoveX(OsbEasing.InOutSine, hitobject.EndTime + FadeDuration, hitobject.EndTime + (FadeDuration * 1.2), hitobject.Position.X, hitobject.Position.X + Random(-2, 2));
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / 128;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + timestep;

                        var complete = hitobject.EndTime - endTime < 5;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = hSprite.PositionAt(startTime);
                        hSprite.MoveX(startTime, endTime, startPosition.X, hitobject.PositionAtTime(endTime).X);

                        if (complete) break;
                        startTime += timestep;
                    }
                }
            }
        }
        public void GenerateY_Special(int StartTime)
        {
            var EndTime = StartTime + 200;
            var hitobjectLayer = GetLayer("");
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (hitobject.StartTime != StartTime)
                    continue;

                var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Fade(OsbEasing.None, hitobject.StartTime - FadeDuration, hitobject.StartTime - 200, 0, 1);
                hSprite.ScaleVec(OsbEasing.In, hitobject.StartTime - FadeDuration, hitobject.StartTime, new OpenTK.Vector2((int)0, (int)0), new OpenTK.Vector2(1000, (int)SpriteScale));
                hSprite.ScaleVec(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeDuration, new OpenTK.Vector2(1000, (int)SpriteScale), new OpenTK.Vector2(1000, 0));
                hSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeDuration, 1, 0);
                hSprite.Additive(hitobject.StartTime, hitobject.EndTime + FadeDuration);
                hSprite.Color(hitobject.StartTime, hitobject.Color);

                var circle = hitobjectLayer.CreateSprite(CirclePath, OsbOrigin.Centre, hitobject.Position);
                circle.Scale(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + (FadeDuration * 2), SpriteScale * 0.8, SpriteScale);
                circle.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + (FadeDuration * 2), 1, 0);
                circle.Additive(hitobject.StartTime, hitobject.StartTime + (FadeDuration * 2));
                circle.Color(hitobject.StartTime, hitobject.Color);

            }
        }

    }
}