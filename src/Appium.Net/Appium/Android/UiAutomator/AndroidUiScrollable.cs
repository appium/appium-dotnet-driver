﻿//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//See the NOTICE file distributed with this work for additional
//information regarding copyright ownership.
//You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using System;
using System.Text;
using OpenQA.Selenium.Appium.Android.Enums;
using OpenQA.Selenium.Appium.Interfaces;

namespace OpenQA.Selenium.Appium.Android.UiAutomator
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Docs: https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable
    /// </remarks>
    public class AndroidUiScrollable : IUiAutomatorStatementBuilder
    {
        private readonly StringBuilder _builder;

        /// <summary>
        /// Creates a new scrollable searcher which will match the first scrollable widget
        /// in the view.
        /// </summary>
        public AndroidUiScrollable()
            : this(new AndroidUiSelector().IsScrollable(true))
        {
        }

        /// <summary>
        /// Creates a new scrollable searcher which will match the first widget
        /// which matches the given UISelector.
        /// </summary>
        /// <param name="uiSelector">
        /// A UiSelector that will be used to find the scrollable container
        /// </param>
        public AndroidUiScrollable(AndroidUiSelector uiSelector)
        {
            _ = uiSelector ?? throw new ArgumentNullException(nameof(uiSelector));
            _builder = new StringBuilder().AppendFormat("new UiScrollable({0})", uiSelector.Build());
        }

        /// <summary>
        /// Performs a backwards fling action with the default number of fling steps (5). If the swipe direction
        /// is set to vertical, then the swipe will be performed from top to bottom. If the swipe direction is set
        /// to horizontal, then the swipes will be performed from left to right. Make sure to take into account
        /// devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to the UiScrollable.flingBackward() method.
        /// </summary>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#flingbackward</remarks>
        public TerminatedStatementBuilder FlingBackward()
        {
            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".flingBackward()");
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a forward fling with the default number of fling steps (5). If the swipe direction is set
        /// to vertical, then the swipes will be performed from bottom to top. If the swipe direction is set to
        /// horizontal, then the swipes will be performed from right to left. Make sure to take into account
        /// devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to the UiScrollable.flingForward() method.
        /// </summary>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#flingforward</remarks>
        public TerminatedStatementBuilder FlingForward()
        {
            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".flingForward()");
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a fling gesture to reach the beginning of a scrollable layout element. The beginning can
        /// be at the top-most edge in the case of vertical controls, or the left-most edge for horizontal
        /// controls. Make sure to take into account devices configured with right-to-left languages like
        /// Arabic and Hebrew.
        /// Maps to the UiScrollable.flingToBeginning(int) method.
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#flingtobeginning</remarks>
        public TerminatedStatementBuilder FlingToBeginning(int maxSwipes)
        {
            if (maxSwipes < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSwipes), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".flingToBeginning({0})", maxSwipes);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a fling gesture to reach the end of a scrollable layout element. The end can be at the
        /// bottom-most edge in the case of vertical controls, or the right-most edge for horizontal controls.
        /// Make sure to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to the UiScrollable.flingToEnd() method.
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#flingtoend</remarks>
        public TerminatedStatementBuilder FlingToEnd(int maxSwipes)
        {
            if (maxSwipes < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSwipes), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".flingToEnd({0})", maxSwipes);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Searches for a child element in the present scrollable container. The search first looks for a
        /// child element that matches the selector you provided, then looks for the content-description in
        /// its children elements. If both search conditions are fulfilled, the method returns a {@ link UiObject}
        /// representing the element matching the selector (not the child element in its subhierarchy containing
        /// the content-description). By default, this method performs a scroll search.
        /// Maps to the UiScrollable.getChildByDescription(UiSelector, String, boolean) method.
        /// </summary>
        /// <param name="uiSelector">
        /// UiSelector for a child in a scollable layout element
        /// </param>
        /// <param name="description">
        /// Content-description to find in the children of the childPattern match (may be a partial match)
        /// </param>
        /// <param name="allowScrollSearch">
        /// Set to true if scrolling is allowed
        /// </param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#getchildbydescription_1</remarks>
        public TerminatedStatementBuilder GetChildByDescription(AndroidUiSelector uiSelector, string description, bool allowScrollSearch = true)
        {
            _ = uiSelector ?? throw new ArgumentNullException(nameof(uiSelector));
            _ = description ?? throw new ArgumentNullException(nameof(description));

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".getChildByDescription({0}, \"{1}\", {2})", 
                uiSelector.Build(), 
                description,
                allowScrollSearch.ToString().ToLowerInvariant());
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Searches for a child element in the present scrollable container that matches the selector you provided.
        /// The search is performed without scrolling and only on visible elements.
        /// Maps to the UiScrollable.getChildByInstance(UiSelector, int) method.
        /// </summary>
        /// <param name="uiSelector"></param>
        /// <param name="instance"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#getchildbyinstance</remarks>
        public TerminatedStatementBuilder GetChildByInstance(AndroidUiSelector uiSelector, int instance)
        {
            _ = uiSelector ?? throw new ArgumentNullException(nameof(uiSelector));

            if (instance < 0)
                throw new ArgumentOutOfRangeException(nameof(instance), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".getChildByInstance({0}, {1})", uiSelector.Build(), instance);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Searches for a child element in the present scrollable container. The search first looks for
        /// a child element that matches the selector you provided, then looks for the text in its children
        /// elements. If both search conditions are fulfilled, the method returns a {@ link UiObject}
        /// representing the element matching the selector (not the child element in its subhierarchy containing
        /// the text). By default, this method performs a scroll search.
        /// Maps to the UiScrollable.getChildByText(UiSelector, String, boolean) method.
        /// </summary>
        /// <param name="uiSelector"></param>
        /// <param name="text"></param>
        /// <param name="allowScrollSearch"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#getchildbytext</remarks>
        public TerminatedStatementBuilder GetChildByText(AndroidUiSelector uiSelector, string text,
            bool allowScrollSearch = true)
        {
            _ = uiSelector ?? throw new ArgumentNullException(nameof(uiSelector));
            _ = text ?? throw new ArgumentNullException(nameof(text));

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".getChildByText({0}, \"{1}\", {2})", 
                uiSelector.Build(), 
                text, 
                allowScrollSearch.ToString().ToLowerInvariant());
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a backward scroll. If the swipe direction is set to vertical, then the swipes will be performed
        /// from top to bottom. If the swipe direction is set to horizontal, then the swipes will be performed
        /// from left to right. Make sure to take into account devices configured with right-to-left languages
        /// like Arabic and Hebrew.
        /// Maps to the UiScrollable.scrollBackward(int) method.
        /// </summary>
        /// <param name="steps">
        /// Number of steps. Use this to control the speed of the scroll action.
        /// </param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#scrollbackward</remarks>
        public TerminatedStatementBuilder ScrollBackward(int steps = 55)
        {
            if (steps < 0)
                throw new ArgumentOutOfRangeException(nameof(steps), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollBackward({0})", steps);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a forward scroll action on the scrollable layout element until the content-description
        /// is found, or until swipe attempts have been exhausted. See <see cref="SetMaxSearchSwipes"/>
        /// Maps to the UiScrollable.scrollDescriptionIntoView(String) method.
        /// </summary>
        /// <param name="description"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#scrolldescriptionintoview</remarks>
        public TerminatedStatementBuilder ScrollDescriptionIntoView(string description)
        {
            _ = description ?? throw new ArgumentNullException(nameof(description));

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollDescriptionIntoView(\"{0}\")", description);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a forward scroll. If the swipe direction is set to vertical, then the swipes will be performed
        /// from bottom to top. If the swipe direction is set to horizontal, then the swipes will be performed
        /// from right to left. Make sure to take into account devices configured with right-to-left languages
        /// like Arabic and Hebrew.
        /// Maps to the UiScrollable.scrollForward(int) method.
        /// </summary>
        /// <param name="steps">
        /// Number of steps. Use this to control the speed of the scroll action.
        /// </param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#scrollforward</remarks>
        public TerminatedStatementBuilder ScrollForward(int steps = 55)
        {
            if (steps < 0)
                throw new ArgumentOutOfRangeException(nameof(steps), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollForward({0})", steps);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Performs a forward scroll action on the scrollable layout element until the text you
        /// provided is visible, or until swipe attempts have been exhausted. See <see cref="SetMaxSearchSwipes"/>
        /// Maps to the UiScrollable.scrollTextIntoView() method.
        /// </summary>
        /// <param name="text"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#scrolltextintoview</remarks>
        public TerminatedStatementBuilder ScrollTextIntoView(string text)
        {
            _ = text ?? throw new ArgumentNullException(nameof(text));

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollTextIntoView(\"{0}\")", text);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Scrolls to the beginning of a scrollable layout element. The beginning can be at the top-most
        /// edge in the case of vertical controls, or the left-most edge for horizontal controls. Make sure
        /// to take into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to the UiScrollable.scrollToBeginning(int, int) method.
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <param name="steps">
        /// Use steps to control the speed, so that it may be a scroll, or fling
        /// </param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#scrolltobeginning</remarks>
        public TerminatedStatementBuilder ScrollToBeginning(int maxSwipes, int steps = 55)
        {
            if (maxSwipes < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSwipes), "Must be 0 (zero) or greater");

            if (steps < 0)
                throw new ArgumentOutOfRangeException(nameof(steps), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollToBeginning({0}, {1})", maxSwipes, steps);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Scrolls to the end of a scrollable layout element. The end can be at the bottom-most edge in
        /// the case of vertical controls, or the right-most edge for horizontal controls. Make sure to take
        /// into account devices configured with right-to-left languages like Arabic and Hebrew.
        /// Maps to the UiScrollable.scrollToEnd(int, int) method.
        /// </summary>
        /// <param name="maxSwipes"></param>
        /// <param name="steps">
        /// Use steps to control the speed, so that it may be a scroll, or fling
        /// </param>
        /// <remarks></remarks>
        public TerminatedStatementBuilder ScrollToEnd(int maxSwipes, int steps = 55)
        {
            if (maxSwipes < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSwipes), "Must be 0 (zero) or greater");

            if (steps < 0)
                throw new ArgumentOutOfRangeException(nameof(steps), "Must be 0 (zero) or greater");

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollToEnd({0}, {1})", maxSwipes, steps);
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Sets the percentage of a widget's size that's considered as no-touch zone when swiping.
        /// The no-touch zone is set as percentage of a widget's total width or height, denoting a margin
        /// around the swipable area of the widget. Swipes must always start and end inside this margin.
        /// This is important when the widget being swiped may not respond to the swipe if started at a
        /// point too near to the edge. The default is 10% from either edge.
        /// Maps to the UiScrollable.setSwipeDeadZonePercentage(double) method.
        /// </summary>
        /// <param name="swipeDeadZonePercentage">
        /// A percentage value from 0 to 1
        /// </param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#setswipedeadzonepercentage</remarks>
        public AndroidUiScrollable SetSwipeDeadZonePercentage(double swipeDeadZonePercentage)
        {
            if (swipeDeadZonePercentage < 0 || swipeDeadZonePercentage > 1)
                throw new ArgumentOutOfRangeException(nameof(swipeDeadZonePercentage), "Must be a value between 0 and 1");

            _builder.AppendFormat(".setSwipeDeadZonePercentage({0})", swipeDeadZonePercentage);
            return this;
        }

        /// <summary>
        /// Sets the scrolling direction of the list.
        /// Maps to UiScrollable.setAsHorizontalList() or UiScrollable.setAsVerticalList() depending on the provided <see cref="ListDirection"/>.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public AndroidUiScrollable SetScrollDirection(ListDirection direction)
        {
            _builder.AppendFormat(".setAs{0}List()", direction);
            return this;
        }

        /// <summary>
        /// Sets the maximum number of scrolls allowed when performing a scroll action in search of a child element.
        /// See <see cref="GetChildByDescription"/> and <see cref="GetChildByText"/>.
        /// Maps to the UiScrollable.setMaxSearchSwipes(int) method.
        /// </summary>
        /// <param name="swipes"></param>
        /// <remarks></remarks>
        public AndroidUiScrollable SetMaxSearchSwipes(int swipes)
        {
            if (swipes < 0)
                throw new ArgumentOutOfRangeException(nameof(swipes), "Must be 0 (zero) or greater");

            _builder.AppendFormat(".setMaxSearchSwipes({0})", swipes);
            return this;
        }

        /// <summary>
        /// Perform a scroll forward action to move through the scrollable layout element until a visible item that matches the selector is found.
        /// Maps to the UiScrollable.scrollIntoView(UiSelector) method.
        /// </summary>
        /// <param name="uiSelector"></param>
        /// <remarks>https://developer.android.com/reference/android/support/test/uiautomator/UiScrollable#scrollintoview</remarks>
        public TerminatedStatementBuilder ScrollIntoView(AndroidUiSelector uiSelector)
        {
            _ = uiSelector ?? throw new ArgumentNullException(nameof(uiSelector));

            var forkedBuilder = new StringBuilder(_builder.ToString());
            forkedBuilder.AppendFormat(".scrollIntoView({0})", uiSelector.Build());
            return new TerminatedStatementBuilder(forkedBuilder);
        }

        /// <summary>
        /// Append raw text to this <see cref="AndroidUiScrollable"/> instance. The target language is Java.
        /// Text entered here will not be checked for validity. Use this at your own risk.
        /// </summary>
        /// <param name="text">
        /// Text to be appended to the UiScrollable command builder.
        /// </param>
        public AndroidUiScrollable AddRawText(string text)
        {
            _ = text ?? throw new ArgumentNullException(nameof(text));

            _builder.Append(text);
            return this;
        }

        /// <summary>
        /// Compiles the current UiScrollable statements that have
        /// been added to this instance.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return Build(false);
        }

        /// <summary>
        /// Compiles the current UiScrollable statements into a valid Java string which can be executed.
        /// </summary>
        /// <param name="terminateStatement">
        /// Should the statement be returned with a semicolon terminator at the end. Defaults to false.
        /// The terminator is only appended to the returned statement string - this <see cref="AndroidUiScrollable"/> is not affected.
        /// </param>
        public string Build(bool terminateStatement)
        {
            if (terminateStatement)
                return _builder + ";";

            return _builder.ToString();
        }
    }
}
