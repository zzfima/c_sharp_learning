using BridgeDesignPattern.Core;
using NUnit.Framework;
using System;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestThreadSchedulingWayName()
        {
            ThreadScheduler unixPTS = new UnixPTS();
            ThreadScheduler unixTSTS = new UnixTSTS();
            ThreadScheduler windowsPTS = new WindowsPTS();
            ThreadScheduler windowsTSTS = new WindowsTSTS();

            Assert.AreEqual("UnixPTS", unixPTS.ThreadSchedulingWayName());
            Assert.AreEqual("UnixTSTS", unixTSTS.ThreadSchedulingWayName());
            Assert.AreEqual("WindowsPTS", windowsPTS.ThreadSchedulingWayName());
            Assert.AreEqual("WindowsTSTS", windowsTSTS.ThreadSchedulingWayName());
        }

        [Test]
        public void TestPreemtiveThreadsAmounts()
        {
            PreemtiveThreadScheduler unixPTS = new UnixPTS();
            PreemtiveThreadScheduler windowsPTS = new WindowsPTS();

            Assert.AreEqual(3, unixPTS.GetPreemtiveThreadsAmount());
            Assert.AreEqual(4, windowsPTS.GetPreemtiveThreadsAmount());
        }

        [Test]
        public void TestGetTimeSliceAmounts()
        {
            TimeSlicedThreadScheduler unixTSTS = new UnixTSTS();
            TimeSlicedThreadScheduler windowsTSTS = new WindowsTSTS();

            Assert.AreEqual(new TimeSpan(0, 0, 0, 0, 11), unixTSTS.GetTimeSliceAmount());
            Assert.AreEqual(new TimeSpan(0, 0, 0, 0, 12), windowsTSTS.GetTimeSliceAmount());
        }
    }
}