// Copyright 2008-2010 Andrej Repin aka Gremlin2
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace Gremlin.FB2Librarian.Import
{
    internal static class DataBindingHelper
    {
        public static Binding AddBinding(this Control control, string propertyName, object dataSource, string dataMember)
        {
            control.DataBindings.Clear();
            Binding binding = control.DataBindings.Add(propertyName, dataSource, dataMember, true);

            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;

            return binding;
        }

        public static Binding AddBinding(this TextBox control, object dataSource, string dataMember)
        {
            return AddBinding(control, "Text", dataSource, dataMember);
        }

        public static Binding AddBinding(this TextEdit control, object dataSource, string dataMember)
        {
            return AddBinding(control, "EditValue", dataSource, dataMember);
        }
    }
}
