using System;
using System.Linq;
using Xamarin.Forms;

namespace RusfootballMobile.Models
{
    public static class StoryExtensions
    {
        private static uint GetUuid(this IStory story)
        {
            var lastSeg = story.Details.Segments.Last();
            return Convert.ToUInt32(lastSeg.Split('-').First());
        }

        public static void SetAttribute(this IStory story, StoryAttributes attributes)
        {
            var key = "s_" + story.GetUuid();
            var props = Application.Current.Properties;

            if (props.TryGetValue(key, out var storedAttributes))
            {
                var castedAttributes = (StoryAttributes) Convert.ToInt32(storedAttributes);
                castedAttributes |= attributes;
                attributes = castedAttributes;
            }

            props[key] = Convert.ToInt32(attributes);
        }

        public static StoryAttributes GetAttributes(this IStory story)
        {
            var key = "s_" + story.GetUuid();
            var props = Application.Current.Properties;
            if (props.TryGetValue(key, out var storedAttributes))
            {
                return (StoryAttributes) Convert.ToInt32(storedAttributes);
            }

            return StoryAttributes.None;
        }
    }
}