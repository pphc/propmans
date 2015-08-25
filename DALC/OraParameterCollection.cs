//***********************************************************************
// Assembly         : DALC
// Author           : Mark Angelo Rivo
// Created          : 02-24-2011
//
// Last Modified By : Mark Angelo Rivo
// Last Modified On : 07-01-2011
// Description      : 
//
// Copyright        : (c) Phinma Properties. All rights reserved.
//***********************************************************************

using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DALC
	{
	/// <summary>
	/// Collection of Oracle Parameter to be used in OraDBHelper2
	/// </summary>
	public sealed class OraParameter : IDisposable
		{

		private OracleParameter paramItem;
		private readonly List<OracleParameter> paramItemCollection = new List<OracleParameter>();


		/// <summary>
		/// add parameter to the parameter collection
		/// </summary>
		/// <param name="paramName">name of parameter</param>
		/// <param name="paramValue">value of parameter,(optional, defaults to NULL if ommitted),</param>
		/// <param name="paramDataType">data type of parameter,(optional, defaults to VARCHAR if ommitted)</param>
		public void AddParameter(string paramName,
							object paramValue,
							[System.Runtime.InteropServices.OptionalAttribute,
							 System.Runtime.InteropServices.DefaultParameterValueAttribute(OracleDbType.Varchar2)]
							OracleDbType paramDataType,
							[System.Runtime.InteropServices.OptionalAttribute,
							System.Runtime.InteropServices.DefaultParameterValueAttribute(ParameterDirection.Input)]
							ParameterDirection direction,
							[System.Runtime.InteropServices.OptionalAttribute,
							System.Runtime.InteropServices.DefaultParameterValueAttribute(false)]
							Boolean isAssociativeArray,
							[System.Runtime.InteropServices.OptionalAttribute,
							System.Runtime.InteropServices.DefaultParameterValueAttribute(100)]
							int paramsize   ) {
			paramItem = new OracleParameter(paramName, paramDataType);

			paramItem.Size = paramsize;
			paramItem.Direction = direction;
			if (paramValue != DBNull.Value) {
			   paramItem.Value = paramValue;  }
		 
	  
			if (isAssociativeArray) {
				paramItem.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
				}


			paramItemCollection.Add(paramItem);
			}


		/// <summary>
		/// add a normal parameter
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="paramValue"></param>
		/// <param name="paramDataType"></param>
		/// <param name="nullInsert">equivalent to NULL</param>
		/// <remarks></remarks>
		///[System.Obsolete("use AddParameter instead",true)]
		public void AddItem(string paramName, 
							object paramValue, 
							[System.Runtime.InteropServices.OptionalAttribute, 
							 System.Runtime.InteropServices.DefaultParameterValueAttribute(OracleDbType.Varchar2)]
							OracleDbType paramDataType, 
							[System.Runtime.InteropServices.OptionalAttribute, 
							System.Runtime.InteropServices.DefaultParameterValueAttribute(false)]  // ERROR: Optional parameters aren't supported in C#
							bool nullInsert) {                  
			paramItem = new OracleParameter(paramName, paramDataType);
			paramItem.Value = paramValue;

			if (nullInsert) {
				paramItem.Status = OracleParameterStatus.NullInsert;
				}

			paramItemCollection.Add(paramItem);
			}



		/// <summary>
		/// parameter used in PL/SQL function and procedure
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="paramValue"></param>
		/// <param name="direction"></param>
		/// <param name="paramDataType"></param>
		/// <param name="nullInsert">equivalent to NULL</param>
		/// <param name="size"></param>
		/// <remarks></remarks>
		///[System.Obsolete("use AddParameter instead", true)]
		public void AddItem(string paramName, object paramValue, ParameterDirection direction, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute(OracleDbType.Varchar2)]  // ERROR: Optional parameters aren't supported in C#
		OracleDbType paramDataType, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute(false)]  // ERROR: Optional parameters aren't supported in C#
		bool nullInsert, [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute(0)]  // ERROR: Optional parameters aren't supported in C#
		int size) {
			paramItem = new OracleParameter(paramName, paramDataType);
			paramItem.Value = paramValue;
			paramItem.Direction = direction;
			if (nullInsert) {
				paramItem.Status = OracleParameterStatus.NullInsert;
				}

			if (size > 0) {
				paramItem.Size = size;
				}

			paramItemCollection.Add(paramItem);
			}

		public List<OracleParameter> GetParameterCollection() {
			if (paramItemCollection.Count > 0) {
				return paramItemCollection;
				}
			else {
				throw new Exception("no items in the parameter collection");
				}
			}

		#region IDisposable Members

		void IDisposable.Dispose() {
			if ((paramItem != null)) {
				paramItem.Dispose();
				}
			}

		#endregion


		}
	}
