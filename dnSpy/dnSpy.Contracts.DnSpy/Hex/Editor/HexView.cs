﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using dnSpy.Contracts.Command;
using dnSpy.Contracts.Hex.Formatting;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace dnSpy.Contracts.Hex.Editor {
	/// <summary>
	/// Hex view
	/// </summary>
	public abstract class HexView : IPropertyOwner {
		/// <summary>
		/// Gets all properties
		/// </summary>
		public PropertyCollection Properties { get; }

		/// <summary>
		/// Gets the command target
		/// </summary>
		public abstract ICommandTargetCollection CommandTarget { get; }

		/// <summary>
		/// Gets the caret
		/// </summary>
		public abstract HexCaret Caret { get; }

		/// <summary>
		/// Gets the selection
		/// </summary>
		public abstract HexSelection Selection { get; }

		/// <summary>
		/// true if the hex view or any of its adornments has focus
		/// </summary>
		public abstract bool HasAggregateFocus { get; }

		/// <summary>
		/// true if the mouse is over the view or any of its adornments
		/// </summary>
		public abstract bool IsMouseOverViewOrAdornments { get; }

		/// <summary>
		/// Gets the nominal line height
		/// </summary>
		public abstract double LineHeight { get; }

		/// <summary>
		/// true if the view is in the process of being laid out
		/// </summary>
		public abstract bool InLayout { get; }

		/// <summary>
		/// true if the view has closed
		/// </summary>
		public abstract bool IsClosed { get; }

		/// <summary>
		/// Gets the editor options
		/// </summary>
		public abstract IEditorOptions Options { get; }

		/// <summary>
		/// Gets the hex view roles
		/// </summary>
		public abstract ITextViewRoleSet Roles { get; }

		/// <summary>
		/// Gets the provisional text highlight
		/// </summary>
		public abstract HexBufferSpan? ProvisionalTextHighlight { get; set; }

		/// <summary>
		/// Gets the hex buffer
		/// </summary>
		public abstract HexBuffer HexBuffer { get; }

		/// <summary>
		/// Gets viewport top
		/// </summary>
		public abstract double ViewportTop { get; }

		/// <summary>
		/// Gets viewport bottom
		/// </summary>
		public abstract double ViewportBottom { get; }

		/// <summary>
		/// Gets/sets viewport left
		/// </summary>
		public abstract double ViewportLeft { get; set; }

		/// <summary>
		/// Gets viewport right
		/// </summary>
		public abstract double ViewportRight { get; }

		/// <summary>
		/// Gets viewport width
		/// </summary>
		public abstract double ViewportWidth { get; }

		/// <summary>
		/// Gets viewport height
		/// </summary>
		public abstract double ViewportHeight { get; }

		/// <summary>
		/// Gets the view scroller
		/// </summary>
		public abstract HexViewScroller ViewScroller { get; }

		/// <summary>
		/// Gets the hex view lines
		/// </summary>
		public abstract HexViewLineCollection HexViewLines { get; }

		/// <summary>
		/// Raised after the view is closed
		/// </summary>
		public abstract event EventHandler Closed;

		/// <summary>
		/// Raised when the view or one of its adornments got focus
		/// </summary>
		public abstract event EventHandler GotAggregateFocus;

		/// <summary>
		/// Raised when the view and all its adornments lost focus
		/// </summary>
		public abstract event EventHandler LostAggregateFocus;

		/// <summary>
		/// Raised when the layout is changed
		/// </summary>
		public abstract event EventHandler<HexViewLayoutChangedEventArgs> LayoutChanged;

		/// <summary>
		/// Raised when viewport height is changed
		/// </summary>
		public abstract event EventHandler ViewportHeightChanged;

		/// <summary>
		/// Raised when viewport width is changed
		/// </summary>
		public abstract event EventHandler ViewportWidthChanged;

		/// <summary>
		/// Raised when viewport left is changed
		/// </summary>
		public abstract event EventHandler ViewportLeftChanged;

		/// <summary>
		/// Raised when the mouse has hovered long enough over something in the view
		/// </summary>
		public abstract event EventHandler<HexMouseHoverEventArgs> MouseHover;

		/// <summary>
		/// Constructor
		/// </summary>
		protected HexView() {
			Properties = new PropertyCollection();
		}

		/// <summary>
		/// Closes the hex view
		/// </summary>
		public abstract void Close();

		/// <summary>
		/// Displays a line in the view
		/// </summary>
		/// <param name="bufferPosition">Position</param>
		/// <param name="verticalDistance">Distance relative to the top or bottom of the view</param>
		/// <param name="relativeTo">The <see cref="HexViewRelativePosition"/></param>
		public abstract void DisplayHexLineContainingBufferPosition(HexBufferPoint bufferPosition, double verticalDistance, HexViewRelativePosition relativeTo);

		/// <summary>
		/// Displays a line in the view
		/// </summary>
		/// <param name="bufferPosition">Position</param>
		/// <param name="verticalDistance">Distance relative to the top or bottom of the view</param>
		/// <param name="relativeTo">The <see cref="HexViewRelativePosition"/></param>
		/// <param name="viewportWidthOverride">Overrides viewport width</param>
		/// <param name="viewportHeightOverride">Overrides viewport height</param>
		public abstract void DisplayHexLineContainingBufferPosition(HexBufferPoint bufferPosition, double verticalDistance, HexViewRelativePosition relativeTo, double? viewportWidthOverride, double? viewportHeightOverride);

		/// <summary>
		/// Gets a hex view line
		/// </summary>
		/// <param name="bufferPosition">Position</param>
		/// <returns></returns>
		public abstract HexViewLine GetHexViewLineContainingBufferPosition(HexBufferPoint bufferPosition);

		/// <summary>
		/// Queues a space reservation stack refresh
		/// </summary>
		public abstract void QueueSpaceReservationStackRefresh();
	}
}