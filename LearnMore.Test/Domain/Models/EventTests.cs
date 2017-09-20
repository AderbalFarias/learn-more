﻿using FluentAssertions;
using LearnMore.Mvc.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LearnMore.Test.Domain.Models
{
    [TestClass]
    public class EventTests
    {
        // A different approach to write these tests is using BDD. 
        // 
        // GivenAnOwnerHasAEvent
        //      WhenHeCancelsTheEvent
        //          IsCanceledShouldBeSetToTrue
        //          EachAttendeeShouldHaveANotification
        //
        // 
        [TestMethod]
        public void Cancel_WhenCalled_ShouldSetIsCanceledToTrue()
        {
            var evt = new Event();

            evt.Cancel();

            evt.IsCanceled.Should().BeTrue();
        }

        [TestMethod]
        public void Cancel_WhenCalled_EachAttendeeShouldHaveANotification()
        {
            var evt = new Event();
            evt.Attendances.Add(new Attendance { Attendee = new ApplicationUser { Id = "1" } });

            evt.Cancel();

            //TODO: This could be pushed into the Event class (eg evt.GetAttendees())
            var attendees = evt.Attendances.Select(a => a.Attendee).ToList();
            attendees[0].UserNotifications.Count.Should().Be(1);
        }
    }
}
