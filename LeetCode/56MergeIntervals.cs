namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Solution
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> ret = new List<Interval>();
            if (intervals == null || intervals.Count == 0)
            {
                return ret;
            }

            Interval[] sortedIntervals = intervals.OrderBy(x => x.start).ToArray();
            int endIndex = 0;
            Interval tmp = sortedIntervals[0];

            while (endIndex < sortedIntervals.Length)
            {
                if (sortedIntervals[endIndex].start <= tmp.end)
                {
                    tmp = new Interval(tmp.start, Math.Max(sortedIntervals[endIndex].end, tmp.end));
                }

                if (sortedIntervals[endIndex].start > tmp.end)
                {
                    ret.Add(tmp);
                    tmp = sortedIntervals[endIndex];
                }
                endIndex++;
            }

            ret.Add(tmp);
            return ret;
        }
    }
}