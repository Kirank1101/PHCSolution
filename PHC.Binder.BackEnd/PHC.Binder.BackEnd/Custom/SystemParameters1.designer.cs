﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHC.Binder.BackEnd.Custom
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="IELSFE_V12")]
	public partial class SystemParametersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSystemParameter(SystemParameter instance);
    partial void UpdateSystemParameter(SystemParameter instance);
    partial void DeleteSystemParameter(SystemParameter instance);
    #endregion
		
		public SystemParametersDataContext() : 
				base("Data Source=192.168.32.243;Initial Catalog=IELSFE_V12;Persist Security Info=True;" +
						"User ID=devuser", mappingSource)
		{
			OnCreated();
		}
		
		public SystemParametersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SystemParametersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SystemParametersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SystemParametersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SystemParameter> SystemParameters
		{
			get
			{
				return this.GetTable<SystemParameter>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SystemParameters")]
	public partial class SystemParameter : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ConfigKey;
		
		private string _Value;
		
		private string _ModuleName;
		
		private string _Description;
		
		private char _ObsInd;
		
		private string _LastModifiedBy;
		
		private System.DateTime _LastModifieddate;
		
		private string _ConfigType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConfigKeyChanging(string value);
    partial void OnConfigKeyChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    partial void OnModuleNameChanging(string value);
    partial void OnModuleNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnObsIndChanging(char value);
    partial void OnObsIndChanged();
    partial void OnLastModifiedByChanging(string value);
    partial void OnLastModifiedByChanged();
    partial void OnLastModifieddateChanging(System.DateTime value);
    partial void OnLastModifieddateChanged();
    partial void OnConfigTypeChanging(string value);
    partial void OnConfigTypeChanged();
    #endregion
		
		public SystemParameter()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConfigKey", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ConfigKey
		{
			get
			{
				return this._ConfigKey;
			}
			set
			{
				if ((this._ConfigKey != value))
				{
					this.OnConfigKeyChanging(value);
					this.SendPropertyChanging();
					this._ConfigKey = value;
					this.SendPropertyChanged("ConfigKey");
					this.OnConfigKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModuleName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ModuleName
		{
			get
			{
				return this._ModuleName;
			}
			set
			{
				if ((this._ModuleName != value))
				{
					this.OnModuleNameChanging(value);
					this.SendPropertyChanging();
					this._ModuleName = value;
					this.SendPropertyChanged("ModuleName");
					this.OnModuleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(100)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ObsInd", DbType="Char(1) NOT NULL")]
		public char ObsInd
		{
			get
			{
				return this._ObsInd;
			}
			set
			{
				if ((this._ObsInd != value))
				{
					this.OnObsIndChanging(value);
					this.SendPropertyChanging();
					this._ObsInd = value;
					this.SendPropertyChanged("ObsInd");
					this.OnObsIndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModifiedBy", DbType="VarChar(15)")]
		public string LastModifiedBy
		{
			get
			{
				return this._LastModifiedBy;
			}
			set
			{
				if ((this._LastModifiedBy != value))
				{
					this.OnLastModifiedByChanging(value);
					this.SendPropertyChanging();
					this._LastModifiedBy = value;
					this.SendPropertyChanged("LastModifiedBy");
					this.OnLastModifiedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModifieddate", DbType="DateTime NOT NULL")]
		public System.DateTime LastModifieddate
		{
			get
			{
				return this._LastModifieddate;
			}
			set
			{
				if ((this._LastModifieddate != value))
				{
					this.OnLastModifieddateChanging(value);
					this.SendPropertyChanging();
					this._LastModifieddate = value;
					this.SendPropertyChanged("LastModifieddate");
					this.OnLastModifieddateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConfigType", DbType="VarChar(3)")]
		public string ConfigType
		{
			get
			{
				return this._ConfigType;
			}
			set
			{
				if ((this._ConfigType != value))
				{
					this.OnConfigTypeChanging(value);
					this.SendPropertyChanging();
					this._ConfigType = value;
					this.SendPropertyChanged("ConfigType");
					this.OnConfigTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
