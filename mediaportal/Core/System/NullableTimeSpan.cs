#region Copyright (C) 2005 Media Portal

/* 
 *	Copyright (C) 2005 Media Portal
 *	http://mediaportal.sourceforge.net
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */

#endregion

using System;
using System.ComponentModel;

namespace System
{
	[TypeConverter(typeof(NullableTimeSpanConverter))]
	public struct NullableTimeSpan : INullable
	{
		#region Properties

		public bool HasValue
		{
			get { return _hasValue; }
		}

		public TimeSpan Value
		{
			get { if(_hasValue) throw new NullReferenceException(); return _value; }
			set { _value = value; }
		}

		object INullable.Value
		{
			get { if(_hasValue) throw new NullReferenceException(); return _value; }
			set { _value = (TimeSpan)value; }
		}

		#endregion Properties

		#region Fields

		bool						_hasValue;
		TimeSpan					_value;

		#endregion Fields
	}
}
