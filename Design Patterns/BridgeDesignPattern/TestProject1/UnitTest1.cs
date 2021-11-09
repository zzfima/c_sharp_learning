using BridgeDesignPattern.Core;
using BridgeDesignPattern.Core.JVM;
using BridgeDesignPattern.Core.Unix;
using BridgeDesignPattern.Core.Windows;
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
            ThreadScheduler jvmPTS = new JVMPTS();
            ThreadScheduler jvmTSTS = new JVMTSTS();

            Assert.AreEqual("UnixPTS", unixPTS.ThreadSchedulingWayName());
            Assert.AreEqual("UnixTSTS", unixTSTS.ThreadSchedulingWayName());
            Assert.AreEqual("WindowsPTS", windowsPTS.ThreadSchedulingWayName());
            Assert.AreEqual("WindowsTSTS", windowsTSTS.ThreadSchedulingWayName());
            Assert.AreEqual("JVMPTS", jvmPTS.ThreadSchedulingWayName());
            Assert.AreEqual("JVMTSTS", jvmTSTS.ThreadSchedulingWayName());
        }

        [Test]
        public void TestPreemtiveThreadsAmounts()
        {
            PreemtiveThreadScheduler unixPTS = new UnixPTS();
            PreemtiveThreadScheduler windowsPTS = new WindowsPTS();
            PreemtiveThreadScheduler jvmPTS = new JVMPTS();

            Assert.AreEqual(3, unixPTS.GetPreemtiveThreadsAmount());
            Assert.AreEqual(4, windowsPTS.GetPreemtiveThreadsAmount());
            Assert.AreEqual(6, jvmPTS.GetPreemtiveThreadsAmount());
        }

        [Test]
        public void TestGetTimeSliceAmounts()
        {
            TimeSlicedThreadScheduler unixTSTS = new UnixTSTS();
            TimeSlicedThreadScheduler windowsTSTS = new WindowsTSTS();
            TimeSlicedThreadScheduler jvmTSTS = new JVMTSTS();

            Assert.AreEqual(new TimeSpan(0, 0, 0, 0, 11), unixTSTS.GetTimeSliceAmount());
            Assert.AreEqual(new TimeSpan(0, 0, 0, 0, 12), windowsTSTS.GetTimeSliceAmount());
            Assert.AreEqual(new TimeSpan(0, 0, 0, 0, 3), jvmTSTS.GetTimeSliceAmount());
        }
    }
}