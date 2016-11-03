#region License, Terms and Conditions
//
// Jayrock - JSON and JSON-RPC for Microsoft .NET Framework and Mono
// Written by Atif Aziz (www.raboof.com)
// Copyright (c) 2005 Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Jayrock.Services
{
    #region Imports

    using System;
    using System.Collections;

    #endregion

    [ Serializable ]
    public sealed class ServiceClassBuilder
    {
        private string _name;
        private ArrayList _methodList;
        private IList _roMethodList;
        private string _description;
        private string _outputDescription;
        private string _inputDescription;
        private string _module;//模块

        /// <summary>
        /// 输出参数
        /// </summary>
        public string OutputDescription
        {
            get { return Mask.NullString(_outputDescription); }
            set { _outputDescription = value; }
        }

        /// <summary>
        /// 输出参数
        /// </summary>
        public string InputDescription
        {
            get { return Mask.NullString(_inputDescription); }
            set { _inputDescription = value; }
        }

        /// <summary>
        /// 模块
        /// </summary>
        public string Module
        {
            get { return Mask.NullString(_module); }
            set { _module = value; }
        }

        public string Name
        {
            get { return Mask.NullString(_name); }
            set { _name = value; }
        }

        public string Description
        {
            get { return Mask.NullString(_description); }
            set { _description = value; }
        }

        public ServiceClass CreateClass()
        {
            return new ServiceClass(this);
        }

        public MethodBuilder DefineMethod()
        {
            MethodBuilder builder = new MethodBuilder(this);
            MethodList.Add(builder);
            return builder;
        }

        public IList Methods
        {
            get 
            {
                if (_roMethodList == null)
                    _roMethodList = ArrayList.ReadOnly(MethodList);
                
                return _roMethodList;
            }
        }

        public bool HasMethods
        {
            get { return _methodList != null && _methodList.Count > 0; }
        }

        private ArrayList MethodList
        {
            get
            {
                if (_methodList == null)
                    _methodList = new ArrayList();
                
                return _methodList;
            }
        }
    }
}