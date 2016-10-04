#region Using Directives
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using JXTPortal.Entities;
using JXTPortal.Data;
#endregion

namespace JXTPortal
{
	/// <summary>
	/// The base class that each component business domain service of the model implements.
	/// </summary>
	[CLSCompliant(true)]
	public abstract partial class ServiceViewBase<Entity> : ServiceViewBaseCore<Entity>
        where Entity : new()
	{

	}
}
