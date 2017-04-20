﻿using System;
using System.ComponentModel;

namespace JXTPortal.Entities
{
	/// <summary>
	///		The data structure representation of the 'JobScreeningQuestions' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IJobScreeningQuestions 
	{
		/// <summary>			
		/// JobScreeningQuestionId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "JobScreeningQuestions"</remarks>
		System.Int32 JobScreeningQuestionId { get; set; }
				
		
		
		/// <summary>
		/// JobId : 
		/// </summary>
		System.Int32?  JobId  { get; set; }
		
		/// <summary>
		/// ScreeningQuestionId : 
		/// </summary>
		System.Int32  ScreeningQuestionId  { get; set; }
		
		/// <summary>
		/// JobArchiveID : 
		/// </summary>
		System.Int32?  JobArchiveId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


